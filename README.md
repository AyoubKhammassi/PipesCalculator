# PipesCalculator

**PipesCalculator** is a Revit Addin that allows you to calculate the diameters of all pipes in a system following the official European standard document [DTU 60.11](http://ebetancheite.fr/assets/dtu-60-11-descentes-pluviales)
The addin now supports 3 pipes materials (*Acier*,*Cuivre*,*PER*), and a limited set of equipment/fixtures(*Sink*,*Urinal*,*etc*), but it was made to be highly extensible by allowing users to add their own materials and their own equipment depending on their use cases.

## How to add an Equipment
The addin uses an Excel sheet named **DATA.xlsx** as a databse, you can find it in the resources folder. To add an equipment add a new entry to the to the *Equipment* sheet, in the first column add the name of the equipment, in the columns B and C add respectively the flow and the coeffecient.

![alt text](Readme%20Images\data_fixtures.PNG "Dafualt Equipments") 


## How to add a Material
To add a new material to the addin, create a new sheet in the DATA.xlsx file, the name of the new sheet must follow this pattern **Tube + MaterialName**. Add as much entries as you want, in each entry, use the column A and B for respectively the internal and external diameters. The column C is for the section. The More entries you add for a material the more accurate the results will be.

![alt text](Readme%20Images\data_material_example.PNG "Tube Acier Example").


## How to install
The addin doesn't have an installer currently, you'll have to install it manually.
1. Clone or Download the project.
2. copy the Resources folder in any path that suits you. In the **Utilities.cs** file, make sure you change the value of resourcesPath to the absolute path of the Resources folder.
3. Build the project and copy the contents of bin\Debug in whatever path you like.
4. Revit uses [addin files](https://forums.autodesk.com/t5/revit-api-forum/revit-addin-file-locations-for-production-release-and-test-debug/td-p/6733987) to indentify addins and their binaries. In the project folder, you can find the file **PipesCalculator.addin**, open it with any text editor and change the Assembly property with the absolute path of the **PipesCalculator.dll** that you copied in the previous step.
5. Save the file and copy it to the follwing folder "C:\ProgramData\Autodesk\Revit\Addins\2019".

#### Note:
* ProgramData is hidden by default.
* The path where to copy addin files might be different depending on the Revit version.
* The addin was tested with Revit 2018 and 2019, it might throw some errors in the newer versions, depending on the SDK updates.

## How to use
1. In Revit, Navigate to Addins > External tools and choose Pipes PipesCalculator.
***
2. Choose the System that you want to work on.
![alt text](Readme%20Images\UI1.PNG "Tube Acier Example").
***
3. The addin will display all the pipes under the chosen system, you can double click the ID of any of the pipes to focus on it in Revit.
Under the Tube column, you can choose the material that you want to apply to the pipe.
![alt text](Readme%20Images\UI2.PNG "Tube Acier Example").
***
4. When you're done applying materials, click Calculate (*Caclculer*) and the addin will calculate all the needed values.
![alt text](Readme%20Images\UI3.PNG "Tube Acier Example").

5. You can finally apply the materials and the new values to the pipes by pressing Apply (*Appliquer*). If you just need the caclulated values, copy them and close the window, revit will rollback and won't apply the modifications.

