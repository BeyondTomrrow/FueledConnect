# FueledConnect Project Roadmap

## Project Vision
AI-powered middleware translating rich mobile data (Voice, GPS, Photos) into legacy-compatible formats (AS400/IBM i) to eliminate manual data entry and preserve operational intelligence.

---

## Phase 1: Foundation & Research
- [ ] **AI Validation Research**
    - [ ] Test different LLMs (GPT-4o, local models) for "Long text to 40-char string" summarization.
    - [ ] Validate entity extraction accuracy for gate codes and names.
    - [ ] Define prompt engineering standards for consistent output.
- [ ] **Technical Environment Setup**
    - [ ] Initialize .NET 8 Backend Project.
    - [ ] Setup Docker environment for local development.
    - [ ] Setup CI/CD pipelines.
- [ ] **UI/UX Design**
    - [ ] Wireframes for the Android mobile app.
    - [ ] Design requirements for offline data synchronization.

## Phase 2: Intelligence Layer (Backend)
- [ ] **API Gateway Development**
    - [ ] Implement HTTPS endpoints for data submission.
    - [ ] Setup request queuing system.
- [ ] **LLM Orchestration**
    - [ ] Integrate AI service calls into the .NET backend.
    - [ ] Implement customer-specific mapping logic (mapping logic for legacy codes).
- [ ] **Data Validation**
    - [ ] Build validation logic to ensure AI output meets legacy character limits.

## Phase 3: Data Capture (Mobile)
- [ ] **Android Native Development**
    - [ ] GPS tracking implementation.
    - [ ] High-resolution photo capture and metadata tagging.
    - [ ] Voice-to-Text recording module.
- [ ] **Offline Sync Engine**
    - [ ] Local database implementation for offline storage.
    - [ ] Background sync service for pushing data when online.

## Phase 4: Integration & Egress
- [ ] **Egress Service**
    - [ ] Develop CSV/Flat-file generation engine.
    - [ ] Implement secure SFTP/FTP transmission logic.
- [ ] **Customer Connectivity**
    - [ ] Setup customer-specific FTP credentials and endpoints.

## Phase 5: Testing & Deployment
- [ ] **User Acceptance Testing (UAT)**
    - [ ] Test with real field data from drivers.
    - [ ] Verify legacy system compatibility with generated files.
- [ ] **Production Rollout**
    - [ ] Deploy backend to production infrastructure.
    - [ ] Release Android app to Play Store/Internal distribution.
