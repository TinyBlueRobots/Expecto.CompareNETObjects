module Expecto

open KellermanSoftware.CompareNetObjects

let defaultComparison (comparisonConfig : ComparisonConfig) = comparisonConfig.IgnoreObjectTypes <- true