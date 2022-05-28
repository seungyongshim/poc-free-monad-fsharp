namespace poc

type In1 = string
type In2 = string
type Out1 = string
type Out2 = string

type IFace =
    abstract member Member1 : input:In1 -> Out1
    abstract member Member2 : input:In2 -> Out2

type FaceInstruction<'a> =
    | Member1 of (In1 * (Out1 -> 'a))
    | Member2 of (In2 * (Out2 -> 'a))

type FaceProgram<'a> =
    | Free of FaceInstruction<FaceProgram<'a>>
    | Pure of 'a

module FaceInstruction =
    let mapI f v =
        match v with
        | Member1 (x, next) -> Member1 (x, next >> f)
        | Member2 (x, next) -> Member2 (x, next >> f)

module FaceProgram =
    let rec bind f v =
        match v with
        | Free x -> x |> FaceInstruction.mapI (bind f) |> Free
        | Pure x -> f x

type FaceBuilder () =
    member this.Bind (x, f) = FaceProgram.bind f x
    member this.Return x = Pure x
    member this.ReturnFrom x = x
    member this.Zero () = Pure ()
