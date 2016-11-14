open Suave                 // always open suave
open Suave.Successful      // for OK-result
open Suave.Web             // for config
open Suave.Filters
open Suave.Operators

let webPart = 
    choose [
        path "/"              >=> (OK "Home")
        path "/store"         >=> (OK "Store")
        path "/store/browse"  >=> (OK "browse")
        path "/store/details" >=> (OK "details")
        pathScan "/store/details/%d" (fun id -> OK (sprintf "Details: %d" id))
        pathScan "/store/details/%s/%d" (fun (a, id) -> OK (sprintf "Artist: %s ID: %d" a id))
    ]
startWebServer defaultConfig webPart
