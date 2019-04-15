module Records

open Expecto

type Record1 =
  { Name : string
    Title : string
    Age : int }

type Record2 =
  { Name : string
    Age : int }

type DU1 = Person of Name : string * Title : string * Age : int

type DU2 = Person of Name : string * Age : int

[<Tests>]
let tests =

  testList "Records" [

    test "records are equal" {
      let person1 =
        { Record1.Name = "foo"
          Title = "bar"
          Age = 1 }
      let person2 =
        { Record2.Name = person1.Name
          Age = person1.Age }
      Expect.objectEqual person1 person2 defaultComparison "objects should be equal"
    }

    test "records not equal" {
      let person1 =
        { Record1.Name = "foo"
          Title = "bar"
          Age = 1 }
      let person2 =
        { Record2.Name = "bar"
          Age = person1.Age }
      Expect.objectNotEqual person1 person2 defaultComparison "objects should not be equal"
    }

    test "anon records are equal" {
      let person1 =
        { Record1.Name = "foo"
          Title = "bar"
          Age = 1 }
      let person2 =
        {| Name = person1.Name
           Age = person1.Age |}
      Expect.objectEqual person1 person2 defaultComparison "objects should be equal"
    }

    test "anon records not equal" {
      let person1 =
        { Record1.Name = "foo"
          Title = "bar"
          Age = 1 }
      let person2 =
        {| Name = "bar"
           Age = person1.Age |}
      Expect.objectNotEqual person1 person2 defaultComparison "objects should not be equal"
    }

    test "DUs are equal" {
      let person1 = DU1.Person("foo", "bar", 1)
      let person2 = DU2.Person("foo", 1)
      Expect.objectEqual person1 person2 defaultComparison "objects should be equal"
    }

    test "DUs are not equal" {
      let person1 = DU1.Person("foo", "bar", 1)
      let person2 = DU2.Person("bar", 1)
      Expect.objectNotEqual person1 person2 defaultComparison "objects should be equal"
    }

  ]