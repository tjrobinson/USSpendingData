#r "packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"
open FSharp.Data
open System.IO

let source = "C:/Projects/USASpendingData/2015_All_Contracts_Full_20150615.csv"

type spendingData = CsvProvider<"C:/Projects/USASpendingData/2015_All_Contracts_Full_20150615.csv", InferRows = 5000, IgnoreErrors = true>

let data = spendingData.Load(source)

let outFile = new StreamWriter("C:/Projects/USASpendingData/output.csv")

printf "Starting to write output"

let outputData = data.Take(100000).Rows
                |> Seq.distinctBy (fun row -> row.Dunsnumber)
                |> Seq.iter
                   (fun row -> outFile.WriteLine(sprintf "%i\t%i\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%i\t%i\t%s\t"
                                                         (row.Dunsnumber)
                                                         (row.Parentdunsnumber.GetValueOrDefault())
                                                         (row.Vendorname)
                                                         (row.Vendoralternatename)
                                                         (row.Vendorlegalorganizationname)
                                                         (row.Vendordoingasbusinessname)
                                                         (row.Divisionname)
                                                         (row.Streetaddress)
                                                         (row.Streetaddress2)
                                                         (row.Streetaddress3)
                                                         (row.City)
                                                         (row.State)
                                                         (row.Zipcode)
                                                         (row.Vendorcountrycode)
                                                         (row.Vendor_state_code)
                                                         (row.Phoneno)
                                                         (row.Faxno)
                                                         (row.Locationcode)
                                                         (row.Statecode)
                                                         (row.Numberofemployees.GetValueOrDefault())
                                                         (row.Annualrevenue.GetValueOrDefault())
                                                         (row.Nonprofitorganizationflag )))