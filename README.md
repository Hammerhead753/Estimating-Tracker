DISCLAIMER: I am not a programmer, I am a construction estimator. This application was vibe coded.

**Estimating Tracker**
Estimating Tracker is a Windows desktop application designed for construction estimators to manage active bids, project deadlines, RFIs, workflow stages, and To Do items.

**Features**
Track current construction bids
View project-specific dashboards
Track bid and RFI due dates
Receive bid, RFI, and To Do notifications
Create project-related and unassigned To Do items
Track completed and overdue tasks
Archive and restore projects
Launch the Windows default email client from a project
Automatically add the solicitation number, project name, and location to the email subject
Switch between light and dark themes
Store project and task information locally

**System Requirements**
**To run the application**
Windows 10 or Windows 11
Microsoft Edge WebView2 Runtime

**To build from source**
Windows 10 or Windows 11
.NET 8 SDK
Visual Studio 2022 recommended
Microsoft Edge WebView2 Runtime

**Building from Source**
Clone or download this repository.
Open Estimating-Tracker.csproj in Visual Studio 2022.
Allow Visual Studio to restore the required NuGet packages.
Build the project.
Run Estimating-Tracker.exe.
The application uses the Microsoft.Web.WebView2 NuGet package.

**Local Data Storage**
Estimating Tracker stores project, archive, and To Do information locally using the application's WebView2 user-data profile.
User data is not included in this repository and is not automatically synchronized between computers.
Deleting the application's local WebView2 data folder may permanently remove locally stored project and task information. Back up important data before deleting or moving the local application-data folder.

**Email Integration**
The Email button opens the Windows default email client and creates a new email with the following project information in the subject line:
Solicitation Number - Project Name - Location
The application does not send emails automatically.

**Notifications**
Estimating Tracker provides notifications while the application is running for:
Bid due dates
RFI due dates
To Do due dates
Overdue To Do items
The application must be running for these notifications to appear.

**Privacy**
Estimating Tracker does not include user project data in the source repository. Users should not upload their WebView2 user-data folder, project information, or other confidential bid information to GitHub.

**License**
This project is licensed under the MIT License. See the LICENSE file for details.

