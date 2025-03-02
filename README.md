# HydrothermalVents

## Introduction

The "HydrothermalVents" project is designed as a coding challenge for applicants, drawing inspiration from the "Advent of Code 2021 - Day 5" problem titled "Hydrothermal Venture" ([Advent of Code 2021 - Day 5](https://adventofcode.com/2021/day/5)). This challenge involves analyzing a list of coordinates that represent lines on a two-dimensional grid, with the objective of determining the number of points where at least two lines overlap.

The coding challenge is structured based on the guidelines provided in *Assignment Example v2.pdf*, which defines the problem statement and expected implementation approach. Additionally, the original problem description and input format are referenced in *Advent_of_code_2021_day5.txt*, which contains details about the hydrothermal vent mapping task.

In the context of this project, applicants are tasked with developing a solution that reads input data specifying line segments, processes this data to map out the lines on a grid, and calculates the points of intersection. The challenge not only assesses an applicant's problem-solving skills but also their ability to implement efficient algorithms to handle potentially large datasets.

By engaging with this project, applicants have the opportunity to demonstrate their proficiency in data parsing, algorithm design, and computational geometry. Additionally, this challenge encourages best practices in software engineering, including writing clean, maintainable, and well-documented code, implementing thorough test cases, and ensuring the solution is robust and scalable. Applicants are expected to follow principles of modular design, test-driven development, and efficient resource management to create a solution that is both reliable and easy to extend.

## Project Structure

- **HydrothermalVents**: Main project containing the solution.
- **HydrothermalVentsTests**: Unit test project containing unit tests for many of the classess used in the solution
- **HydrothermalVentsAcceptanceTests**: Acceptance testing scripts of automatic execution of the project and verification of the output.


## Build and Run

To manually build the C# solution (`.sln`) from the command line, follow these steps:

#### 1. Clone the Repository

Ensure you have Git installed and run the following command in your terminal or command prompt:

```sh
git clone https://github.com/dszammer/HydrothermalVents.git
cd HydrothermalVents
```
### 2. Restore Dependencies
Use the .NET CLI to restore the required dependencies:

```sh
dotnet restore
```

### 3. Build the Solution
Run the following command to compile the project:

```sh
dotnet build
```
Ensure that the build completes successfully without errors.

### 4. Running the Application
To execute the compiled application, use:

```sh
dotnet run --project ./HydrothermalVents/HydrothermalVents.csproj
```

### 5. Command-Line Parameters

The application supports the following command-line arguments:

-i \<relative file location> / --input \<relative file location> 
Specifies the input file(s) to be processed.

-o \<relative file location> / --output \<relative file location>
Specifies the output file(s) where results will be saved.

-q / --quiet
Runs the program without displaying output in the console.

-d / --draw
Generates a visual representation of the line diagram.

-h / --help
Displays help information with usage instructions.

### Build and run via the provided scripts

The project includes several batch (`.bat`) files to streamline the building, testing, and execution processes:

- **`_build.bat`** - Compiles the project, ensuring all necessary dependencies and source files are properly built.
- **`_build_and_run_all_tests.bat`** - Builds the project and runs all unit and integration tests to verify correctness.
- **`_showcase.bat`** - Builds the project and runs a demonstration using a short input file.

## Architecture Overview

![image](./Hydrothermal%20Vents.png
)
