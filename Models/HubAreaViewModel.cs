namespace GenieWeb.Models
{
    public class HubAreaViewModel
    {
        public string ActiveArea { get; set; } = "AIConsultant";
        public bool AdsEnabled { get; set; }
        public AdUnitViewModel? TopAd { get; set; }
        public AdUnitViewModel? BottomAd { get; set; }
    }
}
