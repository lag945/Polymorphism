// Polymorphism.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

class A
{
public:
	virtual int Price()
	{
		return 0;
	}
};

class A2
	: public A
{
};

class A3
	: public A
{
public:
	virtual int Price()
	{
		return 1;
	}
};

class A4
	: public A
{
public:
	int Price()
	{
		return 1;
	}
};

class A5
	: public A4
{
};

class B
{
public:
	virtual int Price() = 0;
};

class B2
	: B
{
public:
	virtual int Price()
	{
		return 1;
	}
};

class D
{
public:
	const char* Name()
	{
		return "D";
	}
};

class D2
	:public B2, public D
{
};

class E
	:public B2
{
public:
	//Error(active)	E1455	member function declared with 'override' does not override a base class member
	int Price()override
	{
		return 1;
	}
};

class E2
	:public B2
{
};

int main()
{
	std::cout << "Hello World!\n";
	A a;
	std::cout << "A:" << a.Price() << std::endl;
	A2 a2;
	std::cout << "A2:" << a2.Price() << std::endl;
	std::cout << "(A)A2:" << ((A)a2).Price() << std::endl;
	A3 a3;
	std::cout << "A3:" << a3.Price() << std::endl;
	std::cout << "(A)A3:" << ((A)a3).Price() << std::endl;
	A4 a4;
	std::cout << "A4:" << a4.Price() << std::endl;
	std::cout << "(A)A4:" << ((A)a4).Price() << std::endl;
	A5 a5;
	std::cout << "A5:" << a5.Price() << std::endl;
	std::cout << "(A)A5:" << ((A)a5).Price() << std::endl;
	std::cout << "(A4)A5:" << ((A4)a4).Price() << std::endl;

	B2 b2;
	std::cout << "B2:" << b2.Price() << std::endl;
	//Error	C2259	'B': cannot instantiate abstract class
	//std::cout << "(B)B2:" << ((B)b2).Price() << std::endl;

	D2 d2;
	std::cout << "D2:" << d2.Price() << std::endl;
	std::cout << "D2:" << d2.Name() << std::endl;

	E e;
	std::cout << "E:" << e.Price() << std::endl;
	E2 e2;
	std::cout << "E2:" << e2.Price() << std::endl;
	std::cout << "(B2)E2:" << ((B2)e2).Price() << std::endl;


}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
