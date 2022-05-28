namespace poc

type In1 = string
type In2 = string
type Out1 = string
type Out2 = string

type IFace =
    abstract member Member1 : input:In1 -> Out1
    abstract member Member2 : input:In2 -> Out2

type FaceInstruction =
    | Member1 of (In1 * Out1)
    | Member2 of (In2 * Out2)
