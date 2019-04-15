module Expect

open KellermanSoftware.CompareNetObjects
open Expecto

let private compareObjects (actual : 'a) (expected : 'b) (comparisonConfig : ComparisonConfig -> unit) message expect =
  let compareLogic = CompareLogic()
  comparisonConfig compareLogic.Config
  let result = compareLogic.Compare(box actual, box expected)
  sprintf "%s\r%s" message result.DifferencesString
  |> expect result.AreEqual

let objectEqual (actual : 'a) (expected : 'b) (comparisonConfig : ComparisonConfig -> unit) message =
  compareObjects actual expected comparisonConfig message Expect.isTrue

let objectNotEqual (actual : 'a) (expected : 'b) (comparisonConfig : ComparisonConfig -> unit) message =
  compareObjects actual expected comparisonConfig message Expect.isFalse