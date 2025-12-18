using GenieWeb.Data;
using GenieWeb.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace GenieWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Enable logging
            builder.Services.AddLogging();

            // Add services to the container
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddScoped<EmailService>();
            builder.Services.AddSingleton<QuizService>(); // Or use AddScoped if needed

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(120);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // MySQL connection
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 32))));

            // JWT Authentication
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings.GetValue<string>("SecretKey");

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

            var app = builder.Build();

            // Middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // app.UseHttpsRedirection(); // Enable in production
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            // Optional: Test email during startup (for diagnostics only)
            Task.Run(() =>
            {
                try
                {
                    var smtpClient = new SmtpClient("mail5015.site4now.net")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("mailserviceagent@ittechgenie.com", "JaiKrishna@5"),
                        EnableSsl = true
                    };

                    var mail = new MailMessage
                    {
                        From = new MailAddress("mailserviceagent@ittechgenie.com", "ItTechGenie"),
                        Subject = "Test Email from GenieWeb Startup",
                        Body = "This is a test email sent during application startup.",
                        IsBodyHtml = false
                    };

                    mail.To.Add("ellurisriram27655@gmail.com");
                    smtpClient.Send(mail);

                    Console.WriteLine("✅ Email sent");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Email failed: " + ex.Message);
                }

            });

            app.Run();
        }
    }
}
