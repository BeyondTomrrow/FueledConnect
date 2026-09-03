# API Specification: FueledConnect Logistics Intelligence

## Overview
This document defines the comprehensive API contract between the FueledConnect Mobile App, the Intelligence Engine, and the client-facing Dashboards.

## Base URL
- **Production:** `https://api.fueledconnect.com/v1`
- **Development:** `https://localhost:5001/v1`

## 1. Authentication & Authorization
All requests must include a Bearer Token.
- **Header:** `Authorization: Bearer <JWT_TOKEN>`
- **Scopes:**
    - `submissions:write`: Ability to submit new field data (Driver apps).
    - `submissions:read`: Ability to view submission history (Dispatchers/Drivers).
    - `registry:read`: Ability to view customers, gates, and locations (Dispatchers).
    - `registry:write`: Ability to create/edit registry items (Admin/Dispatcher).

---

## 2. Submission Endpoints (Data Ingestion)

### 2.1 Submit Field Entry
**Endpoint:** `POST /submissions`
**Description:** Ingests raw data from a driver. The Intelligence Engine automatically determines the Track (Safe-Chain vs. Velocity).

**Request Body:**
```json
{
  "driver_id": "UUID",
  "timestamp": "ISO8601_STRING",
  "track_type": "SAFE_CHAIN" | "VELOCITY",
  "location": {
    "latitude": 37.7749,
    "longitude": -122.4194,
    "altitude": 0.0
  },
  "raw_data": {
    "voice_to_text": "String content from transcription",
    "photos": [
      {
        "type": "gate_photo" | "cargo_photo" | "id_photo",
        "base64": "String",
        "description": "Description"
      }
    ],
    "manual_notes": "Any additional text entered by driver"
  },
  "metadata": {
    "device_type": "android" | "ios",
    "app_version": "1.0.0",
    "session_id": "UUID"
  }
}
```

**Response Body (201 Created):**
```json
{
  "submission_id": "UUID",
  "status": "SUCCESS" | "PENDING" | "FAILED",
  "processed_at": "ISO8601_STRING",
  "intelligence_layer": {
    "legacy_string": "STRING_MAX_40_CHARS",
    "ai_summary": "Human readable summary",
    "extracted_entities": {
      "customer": "Customer Name",
      "gate_code": "1234",
      "location_name": "North Entrance",
      "alerts": ["Temperature Spike", "Gate Delay"]
    }
  },
  "errors": null
}
```

---

## 3. Registry Endpoints (The Knowledge Base)

### 3.1 Get Customers
**Endpoint:** `GET /registry/customers`
**Description:** Retrieve all customers in the system. Support for pagination and filtering.
**Query Params:** `?page=1&size=50&search=GlobalLogix`

### 3.2 Create Customer
**Endpoint:** `POST /registry/customers`
**Description:** Manually add a customer to the registry (e.g., from a new contract).
**Request Body:**
```json
{
  "name": "String",
  "contact_info": "String",
  "default_legacy_code": "String"
}
```

### 3.3 Get Gate Codes
**Endpoint:** `GET /registry/gate-codes`
**Description:** Retrieve all known gate codes.

### 3.4 Create Gate Code
**Endpoint:** `POST /registry/gate-codes`
**Description:** Register a new gate code.
**Request Body:**
```json
{
  "code": "String",
  "associated_location": "String"
}
```

---

## 4. History & Search

### 4.1 Get Submissions by Driver
**Endpoint:** `GET /submissions/driver/{driver_id}`
**Description:** Retrieve a driver's history for their personal dashboard.

### 4.2 Get Submissions by Customer
**Endpoint:** `GET /submissions/customer/{customer_id}`
**Description:** Retrieve all logistics data for a specific client (Dispatcher view).

### 4.3 Search Submissions
**Endpoint:** `GET /submissions/search`
**Query Params:** `?query=gate+delay&start_date=...&end_date=...`

---

## 5. Error Handling
The API uses standard HTTP status codes with a consistent error body:
```json
{
  "error_code": "STRING_CODE",
  "message": "Human readable message",
  "request_id": "UUID"
}
```
- **400:** Validation error (Missing fields, invalid character length).
- **401:** Unauthorized (Missing/Expired token).
- **403:** Forbidden (Insufficient scope for the operation).
- **429:** Rate limit exceeded.
- **503:** Intelligence Engine timeout (AI is taking too long).
