# [Covid19 - Office Space](https://auth0-hack2020.vercel.app/)

## About

Covid19 - Office Space is built to handle life moving forward in the near future.

Employees can:

- Request days in the office

- View occupancy percentages for any office / office section.

Managers can:

- Accept / deny office requests

- Add new employees to the application

HSE Managers can:

- Setup new buildings / sections and manage their rates in the office
- Perform contact tracing given any individual.


## How it Works

A typical flow for a middle level employee would be:

1. Log in to the application.
1. Request any days in the office they need.
1. Accept / deny any subordinate requests that have came in.

HSE Managers are also able to perform contact tracing using the following process:

1. Navigate to the safety/contact-tracing page.
1. Pick the sick employee
1. Pick the date range.

This process retrieves any employees that worked in the same area as the sick individual over the given range.

## Tech Stack

Front End Technologies

- Angular 10

- Angular Material

- Vercel hosts the web app.

Back End Technologies

- ASP.NET Core 3.1 WebAPI + OData

- Entity Framework Core

- Azure hosts the WebAPI

- Azure hosts the MSSQL database.

Cross-stack Technologies

- Auth0 handles authentication and authorization through RBAC on the server + client.

- Azure Devops was used to track work with an agile cycle of 1 day sprints.

## How to run locally, or experience in the cloud..

### Sample Logins

- User: milton.waadams@initech.com | Password: OSCovid19
- User: peter.gibbons@initech.com | Password: OSCovid19
- User: bill.lumbergh@initech.com |Password: OSCovid19

### Cloud Experience

To preview this app in the cloud simply visit us at Vercel! [Covid19-OfficeSpace](https://auth0-hack2020.vercel.app/)

### Run Locally

To run this app locally, follow the steps below.

1. Open the Auth0HackFrontend directory in the command line.
1. Run `npm i` to install needed dependencies
1. Run `ng serve --prod` to run the angular application targetting the cloud api. To run the API locally, you would need a connection string that is not publicly available.