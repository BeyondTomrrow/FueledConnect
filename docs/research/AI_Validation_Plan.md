# AI Validation Research: FueledConnect

## 1. Objective
The primary goal of this research is to validate that Large Language Models (LLMs) can consistently transform unstructured, high-fidelity mobile data (simulated voice-to-text) into highly structured, character-limited "Legacy Strings" ($\le$ 40 characters) that are compatible with AS400/IBM i systems.

## 2. Success Criteria
For any given input, the AI must:
1.  **Identify Core Intent:** Extract the primary action or location.
2.  **Character Constraint:** Output must be $\le$ 40 characters (including spaces).
3.  **Entity Extraction:** Correctly identify Gate Codes, Customer Names, and Locations.
4.  **Consistency:** Provide consistent results for similar inputs.

## 3. Methodology
We will use a "Shot-based" testing approach:
1.  **Zero-Shot:** Provide the instruction and the input.
2.  **Few-Shot:** Provide the instruction, 3-5 examples of input/output pairs, and then the input.
3.  **Model Comparison:** Run the same prompts against:
    *   OpenAI GPT-4o
    *   OpenAI GPT-3.5 Turbo (for cost/speed comparison)
    *   Local LLMs (e.g., Llama 3 / Mistral via Ollama)

## 4. Test Cases (Synthetic Data)
| ID | Category | Raw Driver Input (Simulated Voice-to-Text) | Expected Legacy String (Target) | Why it's an Edge Case |
|:---|:---|:---|:---|:---|
| TC-01 | Simple Gate | "Hey, I'm at the gate. The code is 4455." | GATE 4455 | |
| TC-02 | Customer/Location | "I'm arriving at the GlobalLogix warehouse now, looking for dock 4." | GLOBALLOGIX DOCK 4 | |
| TC-03 | Complex/Rambling | "I'm at the north entrance of the main distribution center, it's super crowded, I'm looking for the loading dock for Customer 'GlobalLogix'. The gate code they gave me is 9988, but it's not working, so I'm just waiting for the guard." | GLOBALLOGIX NORTH DOCK | |
| TC-04 | Error/Issue | "Gate 1234 is broken, I'm stuck outside the main gate for Smith Corp." | SMITH CORP GATE BROKEN | |
| TC-05 | The Long Name | "I am currently at the loading dock for International Logistics & Distribution Solutions, Inc. The gate code is 5566." | INTL LOGISTICS DOCK 5566 | Tests handling of long names/abbreviation. |
| TC-06 | The Storyteller | "So, I was just grabbing a sandwich and then I saw the gate, it's a bit rusty, but the code is 7766 and the customer is Acme Corp. Also, I think I might be late because of the traffic." | ACME CORP GATE 7766 | Tests noise filtering (sandwich, traffic). |
| TC-07 | The Ambiguity | "I'm at the gate. I'm not sure what the code is, it's not working. I'm just waiting here." | GATE NO CODE | Tests handling of missing info/no hallucination. |
| TC-08 | The Correction | "I'm at the loading dock for GlobalLogix. Wait, I mean I'm at the North Entrance. Gate code is 8899." | GLOBALLOGIX NORTH 8899 | Tests prioritization of corrected info. |
| TC-09 | The Multi-Task | "I'm dropping off for Smith Corp at the main gate, then I'm heading over to Jones Inc. for the next one." | SMITH CORP MAIN GATE | Tests isolation of current task from future tasks. |

## 5. Prompt Versioning
We will track iterations of the System Prompt here:
- **v1.0 (Baseline):** "Summarize this driver note into a 40-character string for an AS400 system."
- **v1.1 (Few-Shot):** "Summarize this driver note into a 40-character string. Use format: [CUSTOMER] [LOCATION/ACTION]. Examples: ..."

## 6. Evaluation Results
| Test Case | Model | Prompt Version | Output | Length | Pass/Fail | Notes |
|:---|:---|:---|:---|:---|:---|:---|
| TC-01 | | | | | | |
| TC-02 | | | | | | |
| TC-03 | Claude | v1.0 | GlobalLogix north entrance gate 9988 wait | 39 | PASS | |
| TC-03 | Gemma 4 | v1.0 | GlobalLogix North Entrance Gate 9988 | 36 | PASS | |
| TC-04 | | | | | | |
| TC-05 | | | | | | |
| TC-06 | | | | | | |
| TC-07 | | | | | | |
| TC-08 | | | | | | |
| TC-09 | | | | | | |
