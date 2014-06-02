CSharpCheck
===========

Inspired by [ScalaCheck](http://www.scalacheck.org/), a testing tool for C#, based on property specifications and automatic test data generation.

## An example usage ##

Assuming you have a Person model
```
public class Person
{
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return String.Format("Name:{0}, Age:{1}", Name, Age);
    }
}
```

And a Bar model

```
class Bar
{
    public bool CanEnter(Person person)
    {
        return person.Age >= 18;
    }
}
```

Now we can write a unit test like:

```
var adults = from age in Gen.Choose(18, 35)
            from name in Gen.OneOf("Khalid", "Jaman", "Sajib", "Roni")
            select new Person(name, age);
var adultsCanEnterBars = Prop.ForAll(adults).SuchThat(aBar.CanEnter);
adultsCanEnterBars.Check();
```

Which outputs in console like:

```
+ OK, passed after 10000 tests.
```


Now see how a test fails like:

```
var randomPersons = from age in Gen.Choose(10, 35)
                    from name in Gen.OneOf("Khalid", "Jaman", "Zian", "Ayan")
                    select new Person(name, age);
var randomPersonsCanEnterBar = Prop.ForAll(randomPersons).SuchThat(aBar.CanEnter);
randomPersonsCanEnterBar.Check();

```

Which in my case using NUnit outputs with an exception thrown like:

```
Test method UnitTests.GeneratorTests.PersonModelGenerator threw exception: 
CSharpCheck.TestFailedException: ! Failed after 0 tests, for value: { Item1 = Name:Zian, Age:12 }

```

* See the Unit Tests for Inspiration/Comments
