# Use case relationships

Sometimes use cases are related, or somehow connected. Generally that means two use cases are perfomed on after the other, as a whole. 

For example, a use case such as _Handle Credit_ Payment may be part of several regular use cases, such as _Process Sale_ and _Process Rental_.

Adding the relationships is a way to organize, and clarify the use cases.

We have different kinds of relationships, I will cover two of them here.

The relationships are:
- Include
- Extend

Include is about one use case always requiring another use case to be executed first.

Extend is about one use case can sometimes proceed into another use case.

**Include** relationships are **mandatory** - the base use case cannot complete without the included functionality.

**Extend** relationships are **optional** - the base use case can complete successfully without the extension.