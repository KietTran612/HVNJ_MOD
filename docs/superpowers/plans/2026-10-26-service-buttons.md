# Service Buttons Implementation Plan

> For agentic workers: use superpowers:executing-plans inline for this approved repair.

Goal: repair Box and Upgrade shortcuts using the real NPC protocol observed in logs, leaving Shop work until live confirmation.
Architecture: a small main-thread state machine sends cor(5/6), consumes its own NPC dialogue acknowledgement, sends menu(npc,0,0), then lets the original cmd30 handler open the matching UI. A frame tick enforces deadlines and prevents automatic mod jobs interleaving requests. No map spoofing or automatic transaction retries.
Tech stack: freestanding MSVC C, MASM x64, Python ctypes native tests.
Spec: mod_src/LOG_ANALYSIS_20261026.md, map38 comparison and user M10 approval.

Constraints: no commits; preserve current checkout and other work; keep logging; no Shop changes. Actual server acceptance outside map requires user test; never claim that from simulated tests.

- [x] Write failing tests for NPC5/6, ack ordering, duplicate click, timeout, map change, unrelated/malformed packets and main receive hook.
- [x] Implement hvnj_service.c; integrate menu/top buttons, frame tick and selective receive observer. Default original packets pass unchanged; own ack40 consumed to avoid depending on an absent selected NPC.
- [x] Update old UI tests to assert requests rather than immediate local panels; rebuild generated payload; run service, logger and full mod suite including old diagnostic upgrade.
- [x] Independently review; preserve current DLL backup and install exact tested payload while game closed; document in-game test steps and limits.

Review focus: correlate only one outstanding request; no packet-reader advancement; no null selected-NPC dependency; clear timeout and map change; never invent server authorization.

- [ ] Live user verification of both buttons at map38 and outside village before any Shop repair.

Review fixes: serialize manual NPC requests in both orderings; do not release a pending acknowledgement into the wrong handler. Correlation is bounded by explicit five-second request/drain windows.
