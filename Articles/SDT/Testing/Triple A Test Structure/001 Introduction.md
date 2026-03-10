# Tripple A Test Structure: Introduction

Arrange-Act-Assert (AAA) is a simple way to structure unit tests so they are easy to read and easy to maintain.

## What Is AAA?

- **Arrange**: prepare input data and test setup.
- **Act**: execute the behavior under test.
- **Assert**: verify the expected result.

This keeps a test focused: setup first, one main action second, verification last.

## Why This Structure Helps

- Faster reading: you can scan what the test prepares, does, and checks.
- Easier maintenance: changes are localized to the right section.
- Better debugging: failures are easier to interpret when structure is clear.

## Setup-Execute-Verify (SEV)

You can also call the same structure **Setup-Execute-Verify**.

- Arrange = Setup
- Act = Execute
- Assert = Verify

SEV is an equivalent, dyslexic-friendly phrasing of AAA. Both names refer to the same three-phase test structure.

## What This Learning Path Covers

- In `002`, each phase in detail.
- In `003`, common mistakes and fixes.
- In `004`, full practical examples you can copy.
