# Technical Assignment

## Project Overview

### First Requirement: Facilitates Transactions Between Our Customers and Merchants, 

Write SQL to define data structures that can help track transactions.

**Important Note:** The answer to this requirement is not part of the solution. The SQL script can be found in the following [SQL File](https://github.com/flint21414/TechnicalTest/blob/main/SQL/DatabaseDesign.sql).


### Second Requirement: Checking if a Feature is Enabled

A user profile has 8 boolean settings which determine their functionality:

1. **SMS Notifications Enabled**
2. **Push Notifications Enabled**
3. **Bio-metrics Enabled**
4. **Camera Enabled**
5. **Location Enabled**
6. **NFC Enabled**
7. **Vouchers Enabled**
8. **Loyalty Enabled**

*If a user's settings are represented as a string where each position represents a different setting, write a function to determine if a specific feature is enabled.*

### Third Requirement: Reading and Writing Settings to a File

Write functions to read and write the settings to a file, ensuring minimal file size.

### API Endpoints

- **Endpoint**: `/Users/check-enabled-feature`
  - **Method**: POST

- **Endpoint**: `/Users/check-all-enabled-feature`
  - **Method**: POST

## Steps to Debug/Test the Program

1. **Install Visual Studio Community 2022**
   - Download and install Visual Studio Community 2022 from [this link](https://visualstudio.microsoft.com/vs/).
   - During installation, ensure the following components under **Web & Cloud** are selected:
     - ASP.NET and web development
     - Azure development

2. **Clone the Repository**
   - Clone [this repository](https://github.com/flint21414/TechnicalTest) and place it in your desired directory.

3. **Open the Solution in Visual Studio Community 2022**
   - Launch Visual Studio Community 2022.
   - Open the solution file `TechnicalTest.sln` from the cloned repository.

4. **Start Debugging**
   - Press `F5` or go to **Debug > Start Debugging** in the menu bar.

5. **Verify Application**
   - Once the application is running, it will automatically open `localhost` in your browser. The website should redirect you to Swagger with two endpoints:
     - `/Users/check-enabled-feature`
     - `/Users/check-all-enabled-feature`

6. **Provide Parameters**
   - Supply the necessary parameters for each POST method.

### Expected Results

The results will be based on the parameters you've supplied.

### Test Cases for `/Users/check-enabled-feature`

1. **Input**: `settings = 00000000`, `setting = 7`  
   **Output**: `false`

2. **Input**: `settings = 00000010`, `setting = 7`  
   **Output**: `true`

3. **Input**: `settings = 11111111`, `setting = 4`  
   **Output**: `true`

### Test Cases for `/Users/check-all-enabled-feature`

**Important Note**: The result file needs to be downloaded within the Swagger UI. The output will be a `.gz` (zip) file that needs to be extracted to reveal a flat file.

1. **Input**: `settings = 00000000`  
   **Output**: `FeatureSettings.gz` file containing the following JSON-formatted settings:
   ```json
   {
     "SmsNotifications": false,
     "PushNotifications": false,
     "Biometrics": false,
     "Camera": false,
     "Location": false,
     "NFC": false,
     "Vouchers": false,
     "Loyalty": false
   }

   
2. **Input**: `settings = 01110001`  
   **Output**: `FeatureSettings.gz` file containing the following JSON-formatted settings:
   ```json
   {
     "SmsNotifications": false,
     "PushNotifications": true,
     "Biometrics": true,
     "Camera": true,
     "Location": false,
     "NFC": false,
     "Vouchers": false,
     "Loyalty": true
   }
