module Expect

open Expecto
open KellermanSoftware.CompareNetObjects

let private compareObjects (actual : 'a) (expected : 'b) (comparisonConfig : ComparisonConfig -> unit) message expect =
  let compareLogic = CompareLogic()
  comparisonConfig compareLogic.Config
  let result = compareLogic.Compare(box actual, box expected)
  sprintf "%s\r%s" message result.DifferencesString
  |> expect result.AreEqual

let objectsDeeplyEqual actual expected message =
  compareObjects actual expected ignore message Expect.isTrue

let objectsNotDeeplyEqual actual expected message =
  compareObjects actual expected ignore message Expect.isFalse

let objectsCompare actual expected comparisonConfig message =
  compareObjects actual expected comparisonConfig message Expect.isTrue

let objectsNotCompare actual expected comparisonConfig message =
  compareObjects actual expected comparisonConfig message Expect.isFalse