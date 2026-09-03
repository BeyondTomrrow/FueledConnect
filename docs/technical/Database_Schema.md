# Database Schema: FueledConnect

## Overview
The FueledConnect database is designed to store raw field data, the AI-processed results, and a normalized registry of entities (Customers, Gate Codes, Locations) to provide a searchable intelligence layer.

---

## Entity Relationship Diagram (Conceptual)
- **Users** $\rightarrow$ **Drivers** (One-to-One)
- **Drivers** $\rightarrow$ **FieldSubmissions** (One-to-Many)
- **FieldSubmissions** $\rightarrow$ **ProcessedResults** (One-to-One)
- **ProcessedResults** $\rightarrow$ **Customers**, **GateCodes**, **Locations** (Many-to-Many/Lookups)

---

## Tables

### 1. `Users`
Core account information for both Drivers and Office Staff.
| Column | Type | Description |
|:---|:---|:---|
| `id` | UUID (PK) | Unique identifier |
| `email` | String | Unique email address |
| `password_hash` | String | Hashed password |
| `role` | Enum | `Driver`, `Dispatcher`, `Admin`, `CEO` |
| `created_at` | Timestamp | Record creation time |

### 2. `Drivers`
Profile data for field personnel.
| Column | Type | Description |
|:---|:---|:---|
| `id` | UUID (PK) | Unique identifier |
| `user_id` | UUID (FK) | Link to `Users` table |
| `full_name` | String | Driver's name |
| `phone_number` | String | Contact number |
| `device_id` | String | Unique ID for the Android device |
| `last_active` | Timestamp | Last seen timestamp |

### 3. `FieldSubmissions`
Raw data captured by the mobile app.
| Column | Type | Description |
|:---|:---|:---|
| `id` | UUID (PK) | Unique identifier |
| `driver_id` | UUID (FK) | Link to `Drivers` table |
| `raw_voice_text` | Text | The "raw" transcription from voice-to-text |
| `raw_notes` | Text | Any manual text entered by the driver |
| `latitude` | Decimal | GPS Latitude |
| `longitude` | Decimal | GPS Longitude |
| `photo_urls` | JSONB | Array of URLs to S3/Blob storage |
| `submitted_at` | Timestamp | Time of submission |

### 4. `ProcessedResults`
The output from the AI Intelligence Layer.
| Column | Type | Description |
|:---|:---|:---|
| `id` | UUID (PK) | Unique identifier |
| `submission_id` | UUID (FK) | Link to `FieldSubmissions` |
| `legacy_string` | String(40) | The final AS400-compatible string |
| `ai_summary` | Text | The human-readable summary from the AI |
| `status` | Enum | `Pending`, `Success`, `Failed` |
| `processed_at` | Timestamp | Time the AI finished processing |

### 5. `Customers` (Registry)
Normalized list of customers extracted from AI notes.
| Column | Type | Description |
|:---|:---|:---|
| `id` | UUID (PK) | Unique identifier |
| `name` | String | Customer name (e.g., "GlobalLogix") |
| `is_active` | Boolean | Status |

### 6. `GateCodes` (Registry)
Registry of all gate codes found in the field.
| Column | Type | Description |
|:---|:---|:---|
| `id` | UUID (PK) | Unique identifier |
| `code` | String | The actual code (e.g., "9988") |
| `is_active` | Boolean | Status |

### 7. `Locations` (Registry)
Registry of locations/landmarks.
| Column | Type | Description |
|:---|:---|:---|
| `id` | UUID (PK) | Unique identifier |
| `name` | String | Location name (e.g., "North Entrance") |
| `is_active` | Boolean | Status |

---

## Data Flow Summary
1.  **Submission:** Driver submits data $\rightarrow$ `FieldSubmissions` is populated.
2.  **Processing:** .NET Backend sends data to AI $\rightarrow$ AI returns JSON $\rightarrow$ `ProcessedResults` is populated.
3.  **Extraction:** The backend parses the `extracted_entities` from the AI response. If a Customer, GateCode, or Location doesn't exist in its respective registry table, it creates a new record and links it to the `ProcessedResult`.
4.  **Intelligence:** This allows us to query: *"Show me all Gate Codes associated with GlobalLogix in the last 30 days."*
