module SuaveMusicStore.App

open Suave                 // always open suave
open Suave.Successful      // for OK-result
open Suave.Web             // for config
open Suave.Filters
open Suave.Operators

let browse =
    request (fun r ->
        match r.queryParam "genre" with
        | Choice1Of2 genre -> OK (sprintf "Genre: %s" genre)
        | Choice2Of2 msg -> BAD_REQUEST msg)

let webPart = 
    choose [
        path Path.home              >=> (OK View.index)
        path Path.Store.overview    >=> (OK "Store")
        path Path.store.browse      >=> browse
        pathScan Path.Store.details >=> (fun id -> OK (sprintf "Details: %d" id))
    ]
startWebServer defaultConfig webPart
