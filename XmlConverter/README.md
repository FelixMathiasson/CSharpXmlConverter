# XmlConverter
This is a small C# program created for a coding test.

The goal of the program is to convert a row-based format to an XML format.

## Prerequisites

Before running this project, ensure you have the following installed on your machine:
- Visual Studio 2022 (or higher)
- .NET SDK 8.0 (or higher)

## The task

The input file has the following format:
```
P|first name|surname
T|mobile number|landline number
A|street|city|zipcode
F|name|year of birth
```

Where P may be followed by T, A and F
and F may be followed by T and A.

P may also be followed my multiple F's. Entries may be incomplete.

## Example
The input of:
```
P|Carl Gustaf|Bernadotte
T|0768-101801|08-101801
A|Drottningholms slott|Stockholm|10001
F|Victoria|1977
A|Haga Slott|Stockholm|10002
F|Carl Philip|1979
T|0768-101802|08-101802
P|Barack|Obama
A|1600 Pennsylvania Avenue|Washington, D.C
```

Should result in the following xml format:
```xml
<people>
  <person>
    <firstname>Carl Gustaf</firstname>
    <lastname>Bernadotte</lastname>
    <family>
      <name>Victoria</name>
      <born>1977</born>
      <adress>
        <street>Haga Slott</street>
        <city>Stockholm</city>
        <zip>10002</zip>
      </adress>
    </family>
    <family>
      <name>Carl Philip</name>
      <born>1979</born>
      <phone>
        <mobile>0768-101802</mobile>
        <landline>08-101802</landline>
      </phone>
      <adress>
        <street>1600 Pennsylvania Avenue</street>
        <city>Washington, D.C</city>
        <zip></zip>
      </adress>
    </family>
  </person>
  <person>
    <firstname>Barack</firstname>
    <lastname>Obama</lastname>
  </person>
</people>
```

## Notes

- Ensure that the input file(s) is(are) located in the Data folder inside the project directory.
- The program assumes the file is located relative to the project's root directory. If the file is located elsewhere, modify the path accordingly.