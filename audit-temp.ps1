$path = "C:\Genie\GenieWeb\wwwroot\tutorials\calling-azure-openai-from-csharp.json"
$raw = Get-Content $path -Raw -Encoding UTF8
try { $j = $raw | ConvertFrom-Json } catch { "Valid JSON: NO - $($_.Exception.Message)"; exit 1 }

$canonical = @("overview","learning-objectives","prerequisites","key-concepts",
  "concept-deep-dive-1","concept-deep-dive-2","concept-deep-dive-3","concept-deep-dive-4",
  "ecosystem-and-tools","use-cases","code-examples","step-by-step","limitations-and-caveats",
  "best-practices","quiz","exam","flashcards","interview-qa","glossary","summary","next-steps")
$keys = @($j.sections | ForEach-Object { $_.key })
$orderOk = (($keys -join ",") -eq ($canonical -join ","))

$quiz = @(($j.sections | Where-Object key -eq "quiz").items).Count
$exam = @(($j.sections | Where-Object key -eq "exam").items).Count
$fc   = @(($j.sections | Where-Object key -eq "flashcards").items).Count
$iq   = @(($j.sections | Where-Object key -eq "interview-qa").items).Count
$gl   = @(($j.sections | Where-Object key -eq "glossary").items).Count
$tt   = @($j.tooltips.PSObject.Properties).Count

$anims = 0; $badAnim = 0
foreach ($s in $j.sections) {
  if (-not $s.content) { continue }
  foreach ($b in $s.content) {
    if ($b.type -ne "animation") { continue }
    $anims++
    $ids = @($b.nodes | ForEach-Object { $_.id })
    foreach ($st in $b.steps) {
      foreach ($h in $st.highlight) { if ($h -notin $ids) { $badAnim++; "BAD ANIM HIGHLIGHT: '$h' in '$($b.title)'" } }
    }
  }
}

"Valid JSON            : yes"
"Section count         : $($j.sections.Count)"
"Keys canonical order  : $orderOk"
"Quiz items            : $quiz"
"Exam items            : $exam"
"Flashcards            : $fc"
"Interview Q&A         : $iq"
"Glossary terms        : $gl"
"Tooltip entries       : $tt"
"Animations            : $anims (bad highlights: $badAnim)"
"Subtopics listed      : $($j.subtopics.Count)"
"prev                  : '$($j.prev)'"
"next                  : '$($j.next)'"
"slug                  : '$($j.slug)'"
"tutorialNumber        : $($j.tutorialNumber)"

foreach ($w in @("ItTechGenie","GenieWeb","Genie","newvision")) {
  if ($raw -cmatch $w) { "FORBIDDEN NAME FOUND   : $w" }
}

$quizBad = @(($j.sections | Where-Object key -eq "quiz").items | Where-Object {
  -not $_.options.A -or -not $_.options.B -or -not $_.options.C -or -not $_.options.D -or
  ($_.correctAnswer -notin @("A","B","C","D")) -or -not $_.explanation })
"Quiz items malformed  : $($quizBad.Count)"

$bodyText = ($j.sections | Where-Object { $_.content } | ForEach-Object { $_.content | ConvertTo-Json -Depth 10 }) -join " "
$assessText = ($j.sections | Where-Object { $_.items } | ForEach-Object { $_.items | ConvertTo-Json -Depth 10 }) -join " "
$glossText = (($j.sections | Where-Object key -eq "glossary").items | ForEach-Object { "$($_.term) $($_.definition)" }) -join " "
$ttText = ($j.tooltips.PSObject.Properties | ForEach-Object { "$($_.Name) $($_.Value)" }) -join " "

$checks = [ordered]@{
  "1 chat completion API " = "chat completion"
  "2 embeddings API      " = "embedding"
  "3 temperature         " = "(?i)temperature"
  "4 max tokens          " = "(?i)max tokens"
  "5 errors and retries  " = "(?i)backoff"
  "6 console app build   " = "(?i)console app"
  "7 config and API keys " = "(?i)API key"
}
foreach ($k in $checks.Keys) {
  $t = $checks[$k]
  "Subtopic $k : body=$($bodyText -match $t) assess=$($assessText -match $t) glossary=$($glossText -match $t) tooltip=$($ttText -match $t)"
}

$missing = @()
foreach ($p in $j.tooltips.PSObject.Properties) {
  if ($bodyText.ToLower().IndexOf($p.Name.ToLower()) -lt 0) { $missing += $p.Name }
}
"Tooltip keys missing from body: $($missing.Count)$(if ($missing) { ' -> ' + ($missing -join ', ') })"
