# newvision Tutorial Builder — v1

This file is the master specification for generating course tutorials as JSON
content files. Every tutorial-generation prompt in `AI dotnet/` references this
file and must follow it EXACTLY. One prompt run = one tutorial = one JSON file.

## Output

- Write ONE file per run: `wwwroot/tutorials/<slug>.json` (UTF-8, no BOM required).
- The file must be valid JSON that parses without errors.
- The `<slug>`, course name, category, level, code language, prev/next slugs and
  subtopic list come from the INPUTS block of the prompt being run.

## Top-level JSON schema

```json
{
  "schemaVersion": 1,
  "courseName": "<COURSE NAME from inputs>",
  "category": "<CATEGORY from inputs>",
  "title": "<TOPIC from inputs>",
  "slug": "<SLUG from inputs>",
  "level": "Beginner | Intermediate | Advanced",
  "codeLanguage": "<CODE LANG from inputs>",
  "tutorialNumber": <1-27>,
  "totalTutorials": 27,
  "prev": "<PREV slug, or null if none>",
  "next": "<NEXT slug, or null if none>",
  "breadcrumbs": ["Home", "Learners", "<CATEGORY>", "<TOPIC>"],
  "generatedDate": "YYYY-MM-DD",
  "subtopics": ["<each subtopic from the INPUTS block, verbatim>"],
  "tooltips": { "<term>": "<short hover definition, max ~160 chars>", ... },
  "sections": [ <exactly 21 section objects, in canonical order below> ]
}
```

## The 21 canonical sections

Every tutorial has EXACTLY these 21 sections, in this order, with these
`number` and `key` values. Titles may be adapted to the topic; keys may not.

| #  | key                      | What it contains |
|----|--------------------------|------------------|
| 1  | overview                 | What this tutorial covers, why it matters, who it is for |
| 2  | learning-objectives      | Bullet list of concrete outcomes (one per subtopic minimum) |
| 3  | prerequisites            | What the learner should already know / have installed |
| 4  | key-concepts             | Core definitions and the big picture of the topic |
| 5  | concept-deep-dive-1      | First major subtopic area, explained in depth |
| 6  | concept-deep-dive-2      | Second major subtopic area, explained in depth |
| 7  | concept-deep-dive-3      | Third major subtopic area, explained in depth |
| 8  | concept-deep-dive-4      | Fourth major subtopic area, explained in depth |
| 9  | ecosystem-and-tools      | The products/services/frameworks relevant to the topic |
| 10 | use-cases                | Practical scenarios where developers apply this topic |
| 11 | code-examples            | Complete, commented examples in the input CODE LANG |
| 12 | step-by-step             | Numbered hands-on walkthrough of one end-to-end flow |
| 13 | limitations-and-caveats  | Limits, risks, caveats. If any code example's exact API signature is uncertain, SAY SO here |
| 14 | best-practices           | Do's and common mistakes/anti-patterns |
| 15 | quiz                     | >= 15 multiple-choice questions (A–D, one correct, explanation) |
| 16 | exam                     | >= 15 written exam questions with model answers |
| 17 | flashcards               | >= 15 front/back flashcards |
| 18 | interview-qa             | >= 15 interview questions with strong sample answers |
| 19 | glossary                 | >= 15 term/definition pairs covering every subtopic |
| 20 | summary                  | Key takeaways, bullet list + closing paragraph |
| 21 | next-steps               | Pointer to the NEXT tutorial + practice ideas + official doc names |

The deep-dive sections 5–8 divide the INPUTS subtopic list into four coherent
groups so that EVERY subtopic is covered in depth somewhere in sections 4–12.

## Section object shapes

Body sections (1–14, 20, 21):

```json
{ "number": 1, "key": "overview", "title": "...", "content": [ <blocks> ] }
```

Content blocks (use any mix):

- `{ "type": "paragraph", "text": "..." }`
- `{ "type": "list", "style": "bullet" | "numbered", "items": ["..."] }`
- `{ "type": "code", "language": "csharp", "title": "...", "code": ["line 1", "line 2"] }`
  (code is an ARRAY OF LINES, not one string)
- `{ "type": "table", "headers": ["..."], "rows": [["..."]] }`
- `{ "type": "note", "style": "info" | "tip" | "warning", "text": "..." }`
- `{ "type": "animation", "title": "...", "intro": "one-line setup", "nodes": [ { "id": "a", "label": "Prompt", "sub": "short subtitle" } ], "steps": [ { "highlight": ["a"], "caption": "what is happening in this step" } ] }`
  — a step-based animated diagram the site renderer plays: `nodes` are the boxes
  of a left-to-right pipeline (3–6 nodes, short labels), `steps` highlight one or
  more node ids in sequence with a caption per step (3–7 steps). Use it to make a
  process or flow visible: how data moves, how a loop iterates, how parts interact.
  Every `highlight` id MUST exist in `nodes`.

Assessment sections use `items` instead of `content`:

- quiz (15): `{ "number": n, "question": "...", "options": { "A": "...", "B": "...", "C": "...", "D": "..." }, "correctAnswer": "A", "explanation": "..." }`
- exam (16): `{ "number": n, "question": "...", "modelAnswer": "..." }`
- flashcards (17): `{ "number": n, "front": "...", "back": "..." }`
- interview-qa (18): `{ "number": n, "question": "...", "answer": "..." }`
- glossary (19): `{ "term": "...", "definition": "..." }`

## Hard counts (non-negotiable)

- Sections: exactly 21, canonical keys, canonical order.
- Quiz: >= 15 items. Exam: >= 15. Flashcards: >= 15. Interview Q&A: >= 15.
- Glossary: >= 15 terms. Tooltips: >= 15 entries.
- Animations: >= 2 "animation" content blocks across the body sections, placed
  at the most concept-heavy points (deep dives, step-by-step).
- Tooltip keys must appear VERBATIM (case-insensitive) somewhere in the body
  sections' text — the site renderer turns each first occurrence into a hover
  tooltip showing the definition, so a term that never appears is never seen.
- Every subtopic from INPUTS must appear (a) in the body sections, (b) as at
  least one glossary term, (c) as at least one tooltip, and (d) in at least one
  quiz/exam/flashcard/interview item.

## Content rules

- NEVER mention any company, client, employer, or training-provider name.
  Vendor-neutral, except the Microsoft / Azure / GitHub / .NET technologies the
  topic itself is about (product names like "Azure OpenAI" are fine).
- Write for the LEVEL given in inputs. Beginner = assume no AI background.
- Code examples in the input CODE LANG, correct and runnable in spirit. Do not
  invent APIs; if an exact signature is uncertain, keep the example
  illustrative and disclose that in section 13.
- Explanations in full sentences; no filler. Quiz explanations must teach, not
  just restate the answer letter.
- Set `prev`/`next` exactly to the PREV/NEXT slugs from inputs (JSON `null`
  when the input says "none") so the 27 tutorials chain into one path.

## The 5-step build process

1. **Plan** — map the INPUTS subtopics onto sections 4–12; decide the four
   deep-dive groupings.
2. **Draft the body** — write sections 1–14 with paragraphs, tables, notes and
   code examples.
3. **Write the assessments** — quiz, exam, flashcards, interview Q&A, meeting
   every hard count, covering every subtopic.
4. **Glossary + tooltips** — extract every key term used in the body into the
   glossary section and the top-level `tooltips` map.
5. **Self-audit** — verify the finished JSON mechanically (parse it, count
   items, check keys/order/prev/next/subtopic coverage) and print this audit
   table in the run output:

| Check | Required | Actual | Status |
|-------|----------|--------|--------|
| Valid JSON parses | yes | ... | PASS/FAIL |
| Section count / canonical keys in order | 21 | ... | PASS/FAIL |
| Quiz items | >= 15 | ... | PASS/FAIL |
| Exam items | >= 15 | ... | PASS/FAIL |
| Flashcards | >= 15 | ... | PASS/FAIL |
| Interview Q&A | >= 15 | ... | PASS/FAIL |
| Glossary terms | >= 15 | ... | PASS/FAIL |
| Tooltip entries | >= 15 | ... | PASS/FAIL |
| Subtopics covered (body + glossary + tooltip + assessment) | all | ... | PASS/FAIL |
| prev / next match inputs | yes | ... | PASS/FAIL |
| No company/client/training-provider names | none | ... | PASS/FAIL |

If any check fails, fix the JSON and re-audit before finishing the run.
