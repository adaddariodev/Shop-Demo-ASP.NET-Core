/*
Access Modifiers

PUBLIC
Objects that implement public access modifiers are accessible from everywhere in our project. Therefore, there are no accessibility restrictions


PRIVATE
Objects that implement private access modifiers are accessible only inside a class or a structure. As a result, we can’t access them outside


PROTECTED
The protected keyword implies that the object is accessible inside the class and in all classes that derive from that class. 


INTERNAL
The internal keyword specifies that the object is accessible only inside its own assembly but not in other assemblies


PROTECTED INTERNAL
The protected internal access modifier is a combination of protected and internal. As a result, we can access the protected internal member only in the same assembly or in a derived class in other assemblies (projects)


PRIVATE PROTECTED
The private protected access modifier is a combination of private and protected keywords. We can access members inside the containing class or in a class that derives from a containing class, but only in the same assembly(project). Therefore, if we try to access it from another assembly, we will get an error.




Abstract and Sealed Classes

The ABSTRACT keyword enables you to create classes and class members that are incomplete and must be implemented in a derived class.

The SEALED keyword enables you to prevent the inheritance of a class or certain class members that were previously marked virtual.
*/