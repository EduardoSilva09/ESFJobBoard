# ESFJobBoard API Documentation

## Jobs Endpoint

### Get Jobs
- **Description:** Retrieve a list of available jobs.
- **Endpoint:** `GET /api/jobs`
- **Response:**
  - Status Code: `200 OK`
  - Body: List of job objects.

### Post Job
- **Description:** Post a new job listing.
- **Endpoint:** `POST /api/jobs`
- **Request Body:**
  - Content Type: `application/json`
  - Body: Job object (Title, Description, etc.).
- **Response:**
  - Status Code: `201 Created`
  - Body: Job object of the created job listing.

## Applications Endpoint

### Get Applications
- **Description:** Retrieve a list of job applications.
- **Endpoint:** `GET /api/applications`
- **Response:**
  - Status Code: `200 OK`
  - Body: List of job application objects.

### Apply for Job
- **Description:** Submit a job application for a specific job.
- **Endpoint:** `POST /api/applications`
- **Request Body:**
  - Content Type: `application/json`
  - Body: JobApplication object (JobId, JobSeekerId, etc.).
- **Response:**
  - Status Code: `201 Created`
  - Body: JobApplication object of the created application.

