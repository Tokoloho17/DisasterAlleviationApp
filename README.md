# DisasterAlleviationApp

## Overview
DisasterAlleviationApp is a C# ASP.NET MVC web application designed to help communities report disasters, manage donations, and register volunteers. The app includes user registration, login, donation tracking, volunteer management, and disaster reporting features.

## Features
- **User Registration & Login**  
- **Volunteer Registration & Task Management**  
- **Donation Tracking & Reporting**  
- **Disaster Incident Reporting**  
- **Admin & Account Management**  

## Testing

### Unit & Integration Tests
- Controllers and models were tested to ensure proper functionality.  
- Integration tests used an **in-memory database** to check interactions between controllers and database.  
- Most tests passed; only minor issues occurred during login validation.

### Load & Stress Testing
- Simulated high traffic using **Apache JMeter** to test performance under concurrent users.  
- Measured **response times, throughput, and resource utilization**.  
- One stress test failed under extreme load, showing areas for optimization.

### Test Reports & Feedback
- Test reports documented results, metr
