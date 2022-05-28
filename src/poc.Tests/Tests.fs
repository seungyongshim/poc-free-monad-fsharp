module Tests

open System
open Xunit
open poc

[<Fact>]
let ``My test`` () =
    let member1 in1 = Free(Member1(in1, Pure))
    let member2 in2 = Free(Member2(in2, Pure))

    Assert.True(true)
