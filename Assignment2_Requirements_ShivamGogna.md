# Assignment #2: Requirements  
**Name:** Shivam Gogna  
**Student ID:** 9031137  
**Course:** Software Engineering Principles (SENG8091)  
**Professor:** Shankar Iyer  
**Date:** October 2025  

---

## Purpose  
The purpose of this assignment is to further develop requirement analysis skills by defining both **functional** and **system** requirements for a real-world scenario. This includes identifying clear assumptions, structuring implementation tasks that meet defined outcomes, and planning how to validate the results with the client.

---

## Scenario  
Our client is an **AI developer** who uses **publicly available data through web scraping** to train AI models. They face two major challenges:  

1. Developers need **categorized training questions** that are separated from their answers to improve self-affirmation and data organization.  
2. Developers want to ensure that the training data is **balanced and free from biases**, resulting in more accurate and fair AI models.  

---

## Requirements  

### **Functional Requirements**  
1. The system shall automatically extract and separate training **questions** from their corresponding **answers**.  
2. The system shall categorize questions into relevant **topics** (e.g., technology, science, education) to improve dataset usability.  
3. The system shall include a **bias detection module** that analyzes data for potential imbalances across categories or demographics.  
4. The system shall generate **summary reports** showing dataset distribution and bias metrics.  
5. The system shall allow developers to **upload new datasets** for processing and categorization.  

---

### **System Requirements**  
1. The system shall store categorized data in a **centralized database** with access control.  
2. The system shall support **automated web scraping** to collect and update data from public sources.  
3. The system shall include a **data validation layer** to check the integrity and completeness of extracted information.  
4. The system shall operate on a **secure cloud-based infrastructure** to ensure scalability and data protection.  
5. The system shall maintain **audit logs** for all data processing and modification activities.  

---

## Implementation Tasks  

| Task ID | Task Name | Description | Related Requirement |
|----------|------------|-------------|----------------------|
| T1 | Design Data Extraction Module | Implement automated web scraping and question-answer separation logic. | FR1, SR2 |
| T2 | Create Categorization Engine | Develop logic to classify questions into distinct categories. | FR2 |
| T3 | Implement Bias Detection Tool | Build algorithm to detect and flag dataset biases. | FR3 |
| T4 | Generate Dataset Reports | Create module to summarize dataset balance and statistics. | FR4 |
| T5 | Develop Data Upload Feature | Enable developers to upload and process new datasets. | FR5 |
| T6 | Configure Cloud Database | Set up secure and scalable storage for categorized data. | SR1, SR4 |
| T7 | Implement Data Validation Layer | Check and ensure completeness and correctness of data. | SR3 |
| T8 | Enable Audit Logging | Record system activities for compliance and monitoring. | SR5 |

---

## Assumptions  
- The client will provide **access to existing web-scraped datasets**.  
- Public data sources are legally accessible and do not violate any **privacy regulations**.  
- The client’s team will assist with defining **bias criteria** for analysis.  
- All modules will be developed using **Python-based frameworks** for compatibility with current AI workflows.  
- The system will integrate with **existing AI model training pipelines** after validation.  

---

## Validation Plan  
1. **Requirement Review Meetings** — Conduct biweekly sessions with the client to confirm functional and system requirements.  
2. **Prototype Demonstrations** — Present working modules (data extraction, bias detection, reports) for early feedback.  
3. **User Acceptance Testing (UAT)** — The client will test the system using sample datasets to verify all outcomes.  
4. **Documentation Review** — Share detailed documentation of assumptions, design, and validation steps for client sign-off.  
5. **Feedback Integration** — Address client suggestions in iterative sprints for continuous improvement.  

---

## Git Commit Plan  

To ensure code quality and traceability, all commits will follow best practices:  

- **Commit Frequency:** One commit per logical task completion.  
- **Commit Message Format:**  
  - `feat:` for new features  
  - `fix:` for bug fixes  
  - `docs:` for documentation updates  
  - `test:` for unit test additions  
  - `refactor:` for code improvements  

**Example Commits:**  
```
feat: implement question-answer separation module  
feat: add bias detection algorithm  
fix: corrected dataset validation logic  
docs: updated requirement clarification section  
refactor: optimized categorization engine performance  
```

---

## Conclusion  
The outlined requirements and implementation tasks are designed to help the client overcome key challenges related to **data categorization** and **bias detection**. The assumptions and validation plan ensure alignment with client expectations, and the structured Git approach promotes maintainability and transparency throughout development.

---
