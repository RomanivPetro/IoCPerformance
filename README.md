Ioc Performance
===============

Source code of my performance comparison of the most popular .NET IoC containers:  
[www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison](http://www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison)

Author: Daniel Palme  
Blog: [www.palmmedia.de](http://www.palmmedia.de)  
Twitter: [@danielpalme](http://twitter.com/danielpalme)  

Results
-------
### Explantions
**First value**: Time of single-threaded execution in [ms]  
**Second value**: Time of multi-threaded execution in [ms]  
### Basic Features
|**Container**|**Singleton**|**Transient**|**Combined**|**Complex**|
|:------------|------------:|------------:|-----------:|----------:|
|**[Autofac 4.6.1](https://github.com/autofac/Autofac)**|**1**<br/>**1**|**0**<br/>**0**|**2**<br/>**1**|**6**<br/>**4**|
### Advanced Features
|**Container**|**Generics**|**IEnumerable**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|--------------:|------------------:|---------------:|--------------------------:|
|**[Autofac 4.6.1](https://github.com/autofac/Autofac)**|**2**<br/>**1**|**8**<br/>**4**|**60**<br/>**33**|**14**<br/>**8**|**23**<br/>**13**|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**[Autofac 4.6.1](https://github.com/autofac/Autofac)**|**313**<br/>|**340**<br/>|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](http://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-3470 CPU @ 3.20GHz  
**Memory**: 7.90GB
