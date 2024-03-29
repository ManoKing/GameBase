## 开闭原则（Open Close Principle）

开闭原则，是对扩展开放对修改关闭。这是一条很重要的原则，我们很多代码的设计都要用到这条原则。
这一原则是为了保证系统的可维护性。也就是可以修改。这条原则要求我们在不修改原有代码的基础上增加新的功能，
当然要增加新的代码，只是不修改原来的代码。

## 里氏代换原则（Liskov Substitution Principle）

里氏代换原则说，凡是父类出现的地方，子类一定可以代替父类。也就是说，父类的引用（指针）可以指向子类的对象。
那么一个父类有多个子类的话，在程序运行的过程中，是不是可以动态的指向不同的子对象呢？这样就实现了修改。
在不同的子类里面写不同的方法，然后通过动态的引用，实现动态的调用不同的方法。开闭原则告诉我们要做到对修改关闭对扩展开放，
而里氏代换原则则告诉我们怎么是具体的开闭原则。

## 依赖倒转原则（Dependence Inversion Principle）

依赖倒转原则就是要求我们进行分层，而且层与层之家不能之间相互依赖，而应该是都依赖于一个接口，
一旦某一层出错或者是崩溃，对错误层维护即可，不用改动和错误层相关的层。

## 单一职责原则（Single Responsibility Principle）

单一职责原则是说一个类或者是一个实体或者是一个方法做的事情要单一，不能太复杂。

## 接口隔离原则（Interface Segregation Principle）

接口隔离原则是说我们要用接口，而且要适当的用接口。不能把一个接口写得太大，接口也要保证单一职责原则。

## 迪米特法则（最少知道原则）（Demeter Principle）

为什么叫最少知道原则，就是说：一个实体应当尽量少的与其他实体之间发生相互作用，使得系统功能模块相对独立。

## 合成复用原则（Composite Reuse Principle）

原则是尽量使用合成/聚合的方式，而不是使用继承。