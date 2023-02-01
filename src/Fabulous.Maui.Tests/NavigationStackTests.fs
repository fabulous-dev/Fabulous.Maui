namespace Fabulous.Maui.Tests

open NUnit.Framework

open Fabulous.Maui
open type Fabulous.Maui.View

type Path =
    | A of int
    | B of string

type Msg = Navigated of Path[]

[<TestFixture>]
type ``NavigationStack tests``() =
    [<Test>]
    member _.``Basic test``() =
        let navigationStack =
            NavigationStack(
                [ B "Hello"; A 10 ],
                Navigated,
                fun route ->
                    match route with
                    | A value -> Label(value.ToString())
                    | B value -> Label(value)
            )

        let widget = navigationStack.Compile()

        Assert.Pass()

    [<Test>]
    member _.``Basic test with controller``() =
        let navController = NavigationStackController<Path>()

        let navigationStack =
            NavigationStack(
                [ B "Hello"; A 10 ],
                Navigated,
                fun route ->
                    match route with
                    | A value -> Label(value.ToString())
                    | B value -> Label(value)
            )
                .controller(navController)

        let widget = navigationStack.Compile()

        navController.Push(A 20)
        navController.Pop()
        navController.Push(B "World")

        Assert.Pass()
