namespace poc

type In1 = string
type Out1 = string

type IFace =
    abstract member Member1 : input:In1 -> Out1
    abstract member Member2 : input:In1 -> Out1
