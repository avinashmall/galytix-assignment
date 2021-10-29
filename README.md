# Galytix Backend Assignment

## How to run the project

1. Clone the repository:
```
git clone https://github.com/avinashmall/galytix-assignment.git
```
2. Build the project - Open terminal in the galytix-assignment directory, and run:
```
dotnet build
```
3. Run the project:
```
dotnet run
```
You can also run the project directly using VS Code. Simply install the C# extension, open the folder in VS Code, and simply press F5.

## API exposed

<img width="920" alt="Capture" src="https://user-images.githubusercontent.com/93405677/139494519-eac1955c-95b1-4a18-a428-6fcbee6da520.PNG">


## How to test the project

1. After running the project successfully, open http://localhost:9091/swagger/index.html
2. Click on /api/gwp/avg API.
3. Click on *Try it out*.
4. Enter the following as Request Body:
```
{
  "country": "ae",
  "linesOfBusiness": [
    "freight", "transport"
  ]
}
```
5. Click on *Execute*.
6. You will be able to see the expected results in the Response Body Section.

If you wish to use curl command, you can directly test the project using the following command as an example:
```
curl -X POST "http://localhost:9091/api/gwp/avg" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"country\":\"ae\",\"linesOfBusiness\":[\"freight\",\"transport\"]}"
```

THANK YOU!
