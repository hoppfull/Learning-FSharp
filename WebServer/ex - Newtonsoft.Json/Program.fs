open Newtonsoft.Json
open Newtonsoft.Json.Converters

type Point = { x:int; y:int }

printfn "%s" <| JsonConvert.SerializeObject { x=5; y=8 } // cmd: {"x":5, "y":8}

printfn "%s" <| JsonConvert.SerializeObject [1..5] // cmd: [1,2,3,4,5]

open Newtonsoft.Json.Schema.Generation
let generator = new JSchemaGenerator()

let PointSchema = generator.Generate typeof<Point>

let json1 = """{"x":3, "y":2}"""

let point1 = JsonConvert.DeserializeObject<Point> json1

printfn "x = %i, y = %i" point1.x point1.y // cmd: x = 3, y = 2

open Newtonsoft.Json.Linq
open Newtonsoft.Json.Schema
// validate JSON:
let json2 = """{"x":2, "y":1}"""
let json3 = """{"x":3, "b":2}"""
let json4 = """{"x":3}"""
let json5 = """{"x":3, "y":6, "z":0}"""
let json6 = """[1, 2, 3, 4]"""
let point2 = JObject.Parse json2
let point3 = JObject.Parse json3
let point4 = JObject.Parse json4
let point5 = JObject.Parse json5
let point6 = JArray.Parse json6

printfn "%b" <| point2.IsValid PointSchema // cmd: true
printfn "%b" <| point3.IsValid PointSchema // cmd: false
printfn "%b" <| point4.IsValid PointSchema // cmd: false
printfn "%b" <| point5.IsValid PointSchema // cmd: false
printfn "%b" <| point6.IsValid PointSchema // cmd: false

let x = point2.ToObject<Point>()

printfn "x: %i, y: %i" x.x x.y // cmd: x: 3, y: 2

// http://www.newtonsoft.com/jsonschema/help/html/ValidatingJson.htm
// http://www.newtonsoft.com/json/help/html/SerializingJSON.htm