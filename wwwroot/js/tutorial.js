/* Tutorial page features: dark/light mode, step animations, double-click notes
   (persisted in localStorage, restored on revisit), term tooltips, notes list. */
(function () {
    "use strict";

    var scope = document.querySelector(".tut-scope");
    if (!scope) return;
    var SLUG = scope.dataset.slug || "index";
    var NOTES_KEY = "tutorialNotes_" + SLUG;
    var THEME_KEY = "tutorialTheme";

    /* ---------- safe localStorage ---------- */
    var storeOk = true;
    try { localStorage.setItem("__t", "1"); localStorage.removeItem("__t"); } catch (e) { storeOk = false; }
    function lsGet(key, fallback) {
        if (!storeOk) return fallback;
        try { var v = localStorage.getItem(key); return v == null ? fallback : JSON.parse(v); } catch (e) { return fallback; }
    }
    function lsSet(key, val) {
        if (!storeOk) return;
        try { localStorage.setItem(key, JSON.stringify(val)); } catch (e) { }
    }

    /* =========================================================
       1) DARK / LIGHT MODE (persisted for all tutorial pages)
       ========================================================= */
    var themeBtn = document.getElementById("themeBtn");
    function applyTheme(mode) {
        scope.classList.toggle("dark", mode === "dark");
        if (themeBtn) themeBtn.textContent = mode === "dark" ? "☀️ Light mode" : "🌙 Dark mode";
    }
    var theme = lsGet(THEME_KEY, "light");
    applyTheme(theme);
    if (themeBtn) {
        themeBtn.addEventListener("click", function () {
            theme = theme === "dark" ? "light" : "dark";
            lsSet(THEME_KEY, theme);
            applyTheme(theme);
        });
    }

    /* =========================================================
       2) STEP ANIMATIONS (pipeline diagrams with play/step)
       ========================================================= */
    document.querySelectorAll(".tut-anim").forEach(function (anim) {
        var nodes = anim.querySelectorAll(".anim-node");
        var cap = anim.querySelector(".anim-cap");
        var ind = anim.querySelector(".anim-step-ind");
        var playBtn = anim.querySelector("button.play");
        var prevBtn = anim.querySelector("button.prev");
        var nextBtn = anim.querySelector("button.next");
        var steps;
        try { steps = JSON.parse(anim.querySelector(".anim-steps").textContent) || []; } catch (e) { steps = []; }
        if (!steps.length) return;
        var i = -1, timer = null;

        function show(idx) {
            i = idx;
            var step = steps[i];
            nodes.forEach(function (n) {
                n.classList.toggle("on", step.highlight.indexOf(n.dataset.id) >= 0);
            });
            if (cap) cap.textContent = step.caption;
            if (ind) ind.textContent = "Step " + (i + 1) + " / " + steps.length;
        }
        function stop() {
            if (timer) { clearInterval(timer); timer = null; }
            if (playBtn) playBtn.textContent = "▶ Play";
        }
        function next() {
            if (i >= steps.length - 1) { stop(); show(0); return; }
            show(i + 1);
        }
        if (playBtn) playBtn.addEventListener("click", function () {
            if (timer) { stop(); return; }
            playBtn.textContent = "⏸ Pause";
            if (i >= steps.length - 1) i = -1;
            next();
            timer = setInterval(function () {
                if (i >= steps.length - 1) { stop(); return; }
                next();
            }, 2400);
        });
        if (prevBtn) prevBtn.addEventListener("click", function () { stop(); show(Math.max(0, i - 1)); });
        if (nextBtn) nextBtn.addEventListener("click", function () { stop(); next(); });
        show(0);
    });

    /* =========================================================
       5) TERM TOOLTIPS — hover important technical words
       ========================================================= */
    var tip = document.getElementById("termTip");
    var tooltipData = {};
    var dataEl = document.getElementById("tut-tooltips");
    if (dataEl) { try { tooltipData = JSON.parse(dataEl.textContent) || {}; } catch (e) { } }

    function markTerms() {
        var terms = Object.keys(tooltipData);
        if (!terms.length) return;
        terms.sort(function (a, b) { return b.length - a.length; });
        document.querySelectorAll("section.tut-sec[data-notes='1']").forEach(function (sec) {
            var seen = {};
            var walker = document.createTreeWalker(sec, NodeFilter.SHOW_TEXT, {
                acceptNode: function (n) {
                    if (!n.nodeValue || !n.nodeValue.trim()) return NodeFilter.FILTER_REJECT;
                    if (n.parentElement.closest("pre,code,button,a,input,textarea,.term,.noted-word,h2,dt,.tut-anim")) return NodeFilter.FILTER_REJECT;
                    return NodeFilter.FILTER_ACCEPT;
                }
            });
            var nodes = [];
            while (walker.nextNode()) nodes.push(walker.currentNode);
            nodes.forEach(function (node) {
                terms.forEach(function (term) {
                    if (seen[term]) return;
                    var idx = node.nodeValue.toLowerCase().indexOf(term.toLowerCase());
                    if (idx < 0) return;
                    var before = node.nodeValue[idx - 1], after = node.nodeValue[idx + term.length];
                    if (before && /[A-Za-z0-9-]/.test(before)) return;
                    if (after && /[A-Za-z0-9-]/.test(after)) return;
                    var match = node.splitText(idx);
                    match.splitText(term.length);
                    var span = document.createElement("span");
                    span.className = "term";
                    span.dataset.term = term;
                    span.textContent = match.nodeValue;
                    match.parentNode.replaceChild(span, match);
                    seen[term] = true;
                });
            });
        });
    }
    function showTip(el) {
        if (!tip) return;
        var term = el.dataset.term;
        var def = tooltipData[term];
        if (!def) return;
        tip.innerHTML = "";
        var b = document.createElement("b"); b.textContent = term;
        tip.appendChild(b);
        tip.appendChild(document.createTextNode(def));
        var r = el.getBoundingClientRect();
        var left = window.scrollX + r.left;
        left = Math.max(8, Math.min(left, window.scrollX + document.documentElement.clientWidth - 305));
        tip.style.left = left + "px";
        tip.style.top = (window.scrollY + r.bottom + 7) + "px";
        tip.classList.add("show");
    }
    document.addEventListener("mouseover", function (e) {
        var t = e.target.closest ? e.target.closest(".term") : null;
        if (t) showTip(t);
        else if (tip) tip.classList.remove("show");
    });

    /* =========================================================
       4+6) NOTES — double-click to add; stored client-side only;
       restored on revisit; listed at the bottom; button at top.
       ========================================================= */
    var pop = document.getElementById("notePop");
    var notesSection = document.getElementById("myNotes");
    var notes = lsGet(NOTES_KEY, []);
    var activeNoteId = null;

    function uid() { return "n" + Date.now() + Math.floor(Math.random() * 1000); }

    function sectionInfoFor(el) {
        var card = el.closest("section.tut-sec");
        var h = card ? card.querySelector("h2") : null;
        return { key: card ? card.dataset.key : "", title: h ? h.textContent.trim() : "" };
    }

    function openPop(rect, word, text) {
        if (!pop) return;
        pop.querySelector(".npword").textContent = "“" + word + "”";
        pop.querySelector("textarea").value = text || "";
        pop.style.display = "block";
        var left = window.scrollX + rect.left;
        left = Math.max(8, Math.min(left, window.scrollX + document.documentElement.clientWidth - 282));
        pop.style.left = left + "px";
        pop.style.top = (window.scrollY + rect.bottom + 6) + "px";
        pop.querySelector("textarea").focus();
    }
    function closePop() { if (pop) pop.style.display = "none"; activeNoteId = null; }

    function unwrap(span) {
        var parent = span.parentNode;
        while (span.firstChild) parent.insertBefore(span.firstChild, span);
        parent.removeChild(span);
        parent.normalize();
    }

    // Create note on double-click (not inside the MCQ quiz)
    document.addEventListener("dblclick", function (e) {
        if (!scope.contains(e.target)) return;
        if (e.target.closest("#tab-quiz, .quiz-item, #notePop, #myNotes, button, a, input, textarea, pre, .tut-anim, .nav-tabs")) return;
        var sel = window.getSelection();
        if (!sel || sel.isCollapsed) return;
        var text = sel.toString().trim();
        if (!text || text.length > 120) return;
        var range = sel.getRangeAt(0);
        var span = document.createElement("span");
        span.className = "noted-word";
        try { range.surroundContents(span); } catch (err) { return; }
        sel.removeAllRanges();
        var id = uid();
        span.dataset.id = id;
        activeNoteId = id;
        var info = sectionInfoFor(span);
        notes.push({ id: id, word: text, note: "", sectionKey: info.key, sectionTitle: info.title, ts: Date.now() });
        openPop(span.getBoundingClientRect(), text, "");
    });

    // Click a highlight to edit its note
    document.addEventListener("click", function (e) {
        var s = e.target.closest ? e.target.closest(".noted-word") : null;
        if (s && s.dataset.id) {
            activeNoteId = s.dataset.id;
            var n = notes.filter(function (x) { return x.id === s.dataset.id; })[0];
            openPop(s.getBoundingClientRect(), n ? n.word : s.textContent, n ? n.note : "");
            e.preventDefault();
            return;
        }
        if (pop && pop.style.display === "block" && !e.target.closest("#notePop")) {
            // discard brand-new empty note on click-away
            var cur = notes.filter(function (x) { return x.id === activeNoteId; })[0];
            if (cur && !cur.note) removeNote(activeNoteId); else closePop();
        }
    });

    if (pop) {
        pop.querySelector("button.save").addEventListener("click", function () {
            var n = notes.filter(function (x) { return x.id === activeNoteId; })[0];
            if (n) { n.note = pop.querySelector("textarea").value; lsSet(NOTES_KEY, notes); renderNotesList(); updateCount(); }
            closePop();
        });
        pop.querySelector("button.del").addEventListener("click", function () { removeNote(activeNoteId); });
        pop.querySelector("button.cancel").addEventListener("click", function () {
            var n = notes.filter(function (x) { return x.id === activeNoteId; })[0];
            if (n && !n.note) removeNote(activeNoteId); else closePop();
        });
    }

    function removeNote(id) {
        notes = notes.filter(function (x) { return x.id !== id; });
        lsSet(NOTES_KEY, notes);
        var span = document.querySelector('.noted-word[data-id="' + id + '"]');
        if (span) unwrap(span);
        renderNotesList();
        updateCount();
        closePop();
    }

    // Restore saved highlights when the page is reopened
    function restoreNotes() {
        notes.forEach(function (n) {
            var sec = document.querySelector('section.tut-sec[data-key="' + n.sectionKey + '"]') || scope;
            var walker = document.createTreeWalker(sec, NodeFilter.SHOW_TEXT, {
                acceptNode: function (node) {
                    if (!node.nodeValue || node.nodeValue.indexOf(n.word) < 0) return NodeFilter.FILTER_REJECT;
                    if (node.parentElement.closest(".noted-word,button,a,input,textarea,.quiz-item,pre,.term,.tut-anim")) return NodeFilter.FILTER_REJECT;
                    return NodeFilter.FILTER_ACCEPT;
                }
            });
            var node = walker.nextNode();
            if (!node) return;
            var idx = node.nodeValue.indexOf(n.word);
            var match = node.splitText(idx);
            match.splitText(n.word.length);
            var span = document.createElement("span");
            span.className = "noted-word";
            span.dataset.id = n.id;
            span.textContent = match.nodeValue;
            match.parentNode.replaceChild(span, match);
        });
    }

    // Bottom-of-page notes list
    function renderNotesList() {
        if (!notesSection) return;
        var body = notesSection.querySelector(".notes-body");
        body.innerHTML = "";
        if (!notes.length) {
            var em = document.createElement("div");
            em.className = "notes-empty";
            em.textContent = "No notes yet. Double-click any word or phrase in the tutorial text to add one. Notes are stored only in this browser.";
            body.appendChild(em);
            return;
        }
        notes.slice().sort(function (a, b) { return a.ts - b.ts; }).forEach(function (n) {
            var row = document.createElement("div"); row.className = "noterow";
            var w = document.createElement("div"); w.className = "w";
            w.textContent = "“" + n.word + "”";
            w.title = "Go to this highlight";
            w.addEventListener("click", function () { jumpTo(n.id); });
            var tx = document.createElement("div"); tx.className = "txt";
            tx.textContent = n.note || "(empty note — click the highlighted word to write)";
            var meta = document.createElement("div"); meta.className = "meta";
            meta.textContent = n.sectionTitle || n.sectionKey || "";
            var acts = document.createElement("div"); acts.className = "acts";
            var go = document.createElement("button"); go.type = "button"; go.textContent = "Go to";
            go.addEventListener("click", function () { jumpTo(n.id); });
            var del = document.createElement("button"); del.type = "button"; del.textContent = "Delete";
            del.addEventListener("click", function () { removeNote(n.id); });
            acts.appendChild(go); acts.appendChild(del);
            row.appendChild(w); row.appendChild(tx); row.appendChild(meta); row.appendChild(acts);
            body.appendChild(row);
        });
    }

    // Jump to a highlight — activating its tab first if needed
    function jumpTo(id) {
        var span = document.querySelector('.noted-word[data-id="' + id + '"]');
        if (!span) return;
        var pane = span.closest(".tab-pane");
        if (pane && !pane.classList.contains("active")) {
            var btn = document.querySelector('[data-bs-target="#' + pane.id + '"]');
            if (btn) btn.click();
        }
        setTimeout(function () {
            span.scrollIntoView({ behavior: "smooth", block: "center" });
            span.style.outline = "2px solid #b97a10";
            setTimeout(function () { span.style.outline = ""; }, 1600);
        }, 150);
    }

    function updateCount() {
        var c = document.getElementById("notesCount");
        if (c) c.textContent = notes.length;
    }

    // Top button scrolls to the bottom notes list
    var notesBtn = document.getElementById("notesBtn");
    if (notesBtn && notesSection) {
        notesBtn.addEventListener("click", function () {
            notesSection.scrollIntoView({ behavior: "smooth", block: "start" });
        });
    }

    /* ---------- init ---------- */
    markTerms();
    restoreNotes();
    renderNotesList();
    updateCount();
})();
