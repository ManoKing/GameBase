/*定义：不要存在多于一个导致类变更的原因。通俗的说，即一个类只负责一项职责。
问题由来：类T负责两个不同的职责：职责P1，职责P2。当由于职责P1需求发生改变而需要修改类T时，有可能会导致原本运行正常的职责P2功能发生故障。

解决方案：遵循单一职责原则。分别建立两个类T1、T2，使T1完成职责P1功能，T2完成职责P2功能。这样，当修改类T1时，不会使职责P2发生故障风险；同理，当修改T2时，也不会使职责P1发生故障风险。

说到单一职责原则，很多人都会不屑一顾。因为它太简单了。稍有经验的程序员即使从来没有读过设计模式、从来没有听说过单一职责原则，在设计软件时也会自觉的遵守这一重要原则，因为这是常识。在软件编程中，谁也不希望因为修改了一个功能导致其他的功能发生故障。而避免出现这一问题的方法便是遵循单一职责原则。虽然单一职责原则如此简单，并且被认为是常识，但是即便是经验丰富的程序员写出的程序，也会有违背这一原则的代码存在。为什么会出现这种现象呢？因为有职责扩散。所谓职责扩散，就是因为某种原因，职责P被分化为粒度更细的职责P1和P2。

比如：类T只负责一个职责P，这样设计是符合单一职责原则的。后来由于某种原因，也许是需求变更了，也许是程序的设计者境界提高了，需要将职责P细分为粒度更细的职责P1，P2，这时如果要使程序遵循单一职责原则，需要将类T也分解为两个类T1和T2，分别负责P1、P2两个职责。但是在程序已经写好的情况下，这样做简直太费时间了。所以，简单的修改类T，用它来负责两个职责是一个比较不错的选择，虽然这样做有悖于单一职责原则。（这样做的风险在于职责扩散的不确定性，因为我们不会想到这个职责P，在未来可能会扩散为P1，P2，P3，P4……Pn。所以记住，在职责扩散到我们无法控制的程度之前，立刻对代码进行重构。）

举例说明，用一个类描述动物呼吸这个场景：*/

class Animal{
	public void breathe(String animal){
		System.out.println(animal+"呼吸空气");
	}
}
public class Client{
	public static void main(String[] args){
		Animal animal = new Animal();
		animal.breathe("牛");
		animal.breathe("羊");
		animal.breathe("猪");
	}
} 
/*
运行结果：

牛呼吸空气

羊呼吸空气

猪呼吸空气

程序上线后，发现问题了，并不是所有的动物都呼吸空气的，比如鱼就是呼吸水的。修改时如果遵循单一职责原则，需要将Animal类细分为陆生动物类Terrestrial，水生动物Aquatic，代码如下：
*/
class Terrestrial{
	public void breathe(String animal){
		System.out.println(animal+"呼吸空气");
	}
}
class Aquatic{
	public void breathe(String animal){
		System.out.println(animal+"呼吸水");
	}
}

public class Client{
	public static void main(String[] args){
		Terrestrial terrestrial = new Terrestrial();
		terrestrial.breathe("牛");
		terrestrial.breathe("羊");
		terrestrial.breathe("猪");
		
		Aquatic aquatic = new Aquatic();
		aquatic.breathe("鱼");
	}
}
/*
运行结果：

牛呼吸空气

羊呼吸空气

猪呼吸空气

鱼呼吸水

我们会发现如果这样修改花销是很大的，除了将原来的类分解之外，还需要修改客户端。而直接修改类Animal来达成目的虽然违背了单一职责原则，但花销却小的多，代码如下：
*/
class Animal{
	public void breathe(String animal){
		if("鱼".equals(animal)){
			System.out.println(animal+"呼吸水");
		}else{
			System.out.println(animal+"呼吸空气");
		}
	}
}

public class Client{
	public static void main(String[] args){
		Animal animal = new Animal();
		animal.breathe("牛");
		animal.breathe("羊");
		animal.breathe("猪");
		animal.breathe("鱼");
	}
} 
// 可以看到，这种修改方式要简单的多。但是却存在着隐患：有一天需要将鱼分为呼吸淡水的鱼和呼吸海水的鱼，则又需要修改Animal类的breathe方法，而对原有代码的修改会对调用“猪”“牛”“羊”等相关功能带来风险，也许某一天你会发现程序运行的结果变为“牛呼吸水”了。这种修改方式直接在代码级别上违背了单一职责原则，虽然修改起来最简单，但隐患却是最大的。还有一种修改方式：

class Animal{
	public void breathe(String animal){
		System.out.println(animal+"呼吸空气");
	}

	public void breathe2(String animal){
		System.out.println(animal+"呼吸水");
	}
}

public class Client{
	public static void main(String[] args){
		Animal animal = new Animal();
		animal.breathe("牛");
		animal.breathe("羊");
		animal.breathe("猪");
		animal.breathe2("鱼");
	}
} 
/*
可以看到，这种修改方式没有改动原来的方法，而是在类中新加了一个方法，这样虽然也违背了单一职责原则，但在方法级别上却是符合单一职责原则的，因为它并没有动原来方法的代码。这三种方式各有优缺点，那么在实际编程中，采用哪一中呢？其实这真的比较难说，需要根据实际情况来确定。我的原则是：只有逻辑足够简单，才可以在代码级别上违反单一职责原则；只有类中方法数量足够少，才可以在方法级别上违反单一职责原则；

例如本文所举的这个例子，它太简单了，它只有一个方法，所以，无论是在代码级别上违反单一职责原则，还是在方法级别上违反，都不会造成太大的影响。实际应用中的类都要复杂的多，一旦发生职责扩散而需要修改类时，除非这个类本身非常简单，否则还是遵循单一职责原则的好。

遵循单一职责原的优点有：

可以降低类的复杂度，一个类只负责一项职责，其逻辑肯定要比负责多项职责简单的多；
提高类的可读性，提高系统的可维护性；
变更引起的风险降低，变更是必然的，如果单一职责原则遵守的好，当修改一个功能时，可以显著降低对其他功能的影响。
需要说明的一点是单一职责原则不只是面向对象编程思想所特有的，只要是模块化的程序设计，都适用单一职责原则。
*/