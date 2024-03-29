# Project Overview

## Patterns

The project follows certain design patterns to enhance maintainability, scalability, and code organization:

- **CQRS (Command Query Responsibility Segregation):**
  - The project uses the CQRS pattern to separate the read and write operations, allowing for more flexible and scalable architecture.

- **Repository Pattern:**
  - Repositories are employed to abstract the data access layer, promoting a clean separation between business logic and data operations.

- **Mediator Pattern:**
  - MediatR is used as a mediator library to implement the mediator pattern, facilitating communication between components, particularly for command and query handling.

## Technologies

The project leverages the following technologies and frameworks:

- **ASP.NET Core:**
  - The backend is developed using ASP.NET Core, providing a cross-platform, high-performance framework for building modern, cloud-based, and internet-connected applications.

- **Entity Framework Core:**
  - Entity Framework Core is utilized as the Object-Relational Mapping (ORM) tool, simplifying database interactions and providing a clean data access layer.

- **MediatR:**
  - MediatR is employed for implementing the mediator pattern, facilitating communication between different parts of the application.

- **Microsoft SQL Server:**
  - The project uses Microsoft SQL Server as the relational database management system.

## Resources

The following resources were instrumental in the development of this project:

- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/)
- [MediatR Documentation](https://github.com/jbogard/MediatR)

# ESFJobBoard API Documentation

## Jobs Controller

### Get All Jobs

- **HTTP Verb:** GET
- **Description:** Retrieve a list of all jobs.
- **Endpoint:** `/api/jobs`
- **Response:**
  - **Status Code:** 200 OK
  - **Body:** Array of Job objects.

### Get Job by ID

- **HTTP Verb:** GET
- **Description:** Retrieve a job by its ID.
- **Endpoint:** `/api/jobs/{id}`
- **Response:**
  - **Status Code:** 200 OK
  - **Body:** Job object.

### Create Job

- **HTTP Verb:** POST
- **Description:** Create a new job.
- **Endpoint:** `/api/jobs`
- **Request Body:**
  - Title (string)
  - Description (string)
- **Response:**
  - **Status Code:** 201 Created
  - **Body:** ID of the created job.

### Update Job

- **HTTP Verb:** PUT
- **Description:** Update an existing job.
- **Endpoint:** `/api/jobs/{id}`
- **Request Body:**
  - Title (string)
  - Description (string)
- **Response:**
  - **Status Code:** 204 No Content

### Delete Job

- **HTTP Verb:** DELETE
- **Description:** Delete a job by its ID.
- **Endpoint:** `/api/jobs/{id}`
- **Response:**
  - **Status Code:** 204 No Content

## Applications Controller

### Get All Applications

- **HTTP Verb:** GET
- **Description:** Retrieve a list of all job applications.
- **Endpoint:** `/api/applications`
- **Response:**
  - **Status Code:** 200 OK
  - **Body:** Array of JobApplication objects.

### Get Application by ID

- **HTTP Verb:** GET
- **Description:** Retrieve a job application by its ID.
- **Endpoint:** `/api/applications/{id}`
- **Response:**
  - **Status Code:** 200 OK
  - **Body:** JobApplication object.

### Apply for Job

- **HTTP Verb:** POST
- **Description:** Apply for a job.
- **Endpoint:** `/api/applications`
- **Request Body:**
  - JobId (int)
  - JobSeekerId (int)  
- **Response:**
  - **Status Code:** 201 Created
  - **Body:** ID of the created job application.

### Update Application

- **HTTP Verb:** PUT
- **Description:** Update an existing job application.
- **Endpoint:** `/api/applications/{id}`
- **Request Body:**
  - // Updateable application properties
- **Response:**
  - **Status Code:** 204 No Content

### Withdraw Application

- **HTTP Verb:** DELETE
- **Description:** Withdraw a job application by its ID.
- **Endpoint:** `/api/applications/{id}`
- **Response:**
  - **Status Code:** 204 No Content

### Get Applications by Job ID

- **HTTP Verb:** GET
- **Description:** Retrieve a list of job applications for a specific job.
- **Endpoint:** `/api/applications/job/{jobId}`
- **Response:**
  - **Status Code:** 200 OK
  - **Body:** Array of JobApplication objects.

### Get Applications by JobSeeker ID

- **HTTP Verb:** GET
- **Description:** Retrieve a list of job applications for a specific job seeker.
- **Endpoint:** `/api/applications/jobseeker/{jobSeekerId}`
- **Response:**
  - **Status Code:** 200 OK
  - **Body:** Array of JobApplication objects.

## Users Controller

### Get All Users

- **HTTP Verb:** GET
- **Description:** Retrieves a list of all users. 
- **Endpoint:** `/api/users`
- **Response:**
  - **Status Code:** 200 OK

### Get User by ID

- **HTTP Verb:** GET
- **Description:** Retrieves a user by their ID. 
- **Endpoint:** `/api/users/{id}`
- **Response:**
  - **Status Code:** 200 OK

### Create User

- **HTTP Verb:** POST
- **Description:** Creates a new user. 
- **Endpoint:** `/api/users`
- **Request Body:**
  - FirstName (String)
  - LastName (String)
  - Email (String)
  - Username (String)
  - Password (String)
  - UserType (Int)
- **Response:**
  - **Status Code:** 201 Created

### Update User

- **HTTP Verb:** PUT
- **Description:** Updates an existing user by ID. Requires updated user details in the request body.
- **Endpoint:** `/api/users/{id}`
- **Request Body:**
  - FirstName (String)
  - LastName (String)
  - Email (String)
- **Response:**
  - **Status Code:** 204 No Content

### Delete User

- **HTTP Verb:** DELETE
- **Description:** Deletes a user by ID. Returns no content.
- **Endpoint:** `/api/users/{id}`
- **Response:**
  - **Status Code:** 204 No Content