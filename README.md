# HelloAssembly

通过反射初始化模块

这个实现来源于引入不同 SDK，而由统一入口初始化的需求。如下图

![intro](https://user-images.githubusercontent.com/1450714/121664422-0b86d880-cada-11eb-8ebc-c298f837918e.png)

而由于项目不同，可能引入不同的`模块组合`，此时希望 Bootstrap 能够`智能`的初始化，即根据引入哪些模块，则对哪些模块进行初始化。

## 实现方式

1. 通过 Assembly assembly = Assembly.GetCallingAssembly(); 获得项目所在程序集
2. 通过 AssemblyName[] refNames = assembly.GetReferencedAssemblies(); 获得项目依赖的程序集
3. 根据 refNames 中确定有哪些`模块`需要初始化
4. 通过 Assembly.Load(assemblyName) 加载对应的程序集，反射得到初始化入口，进行初始化

### 注意

Assembly.GetCallingAssembly() 是相对于`函数调用`而言的（并非是相对于 Assembly 引用而言）。

所以函数的调用，将有可能影响`项目所在程序集`的获取。

## 思考

这种实现方式用到了反射，在 Unity 中还需谨慎使用。

而从这个需求入手，可以考虑`延迟初始化`。使不同模块依赖于 Bootstrap，Bootstrap 初始化后，将配置信息保存起来，再项目中使用到具体模块后，模块根据 Bootstrap 在进行初始化。
