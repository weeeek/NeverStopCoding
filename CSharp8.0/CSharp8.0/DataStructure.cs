﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8._0
{
    public class DataStructure
    {
        public void Main() {
            /*
             Array数组：
                数组是可以再内存中连续存储多个元素的结构，在内存中的分配也是连续的，数组中的元素通过数组下标进行访问。
                优点：
                    1、按照索引查询元素速度快
                    2、按照索引遍历数组方便

                缺点：
                    1、数组的大小固定后就无法扩容了
                    2、数组只能存储一种类型的数据
                    3、添加，删除的操作慢，因为要移动其他的元素。

                适用场景：
                    频繁查询，对存储空间要求不大，很少增加和删除的情况。

             Stack栈：
                栈是一种特殊的线性表，仅能在线性表的一端操作，栈顶允许操作，栈底不允许操作。 
                特点：先进后出，后进先出。
                从栈顶放入元素的操作叫入栈，取出元素叫出栈。
                 
                应用：返回&前进、撤销&重做、卡牌判定

             Queue队列：
                队列与栈一样，也是一种线性表，不同的是，队列可以在一端添加元素，在另一端取出元素。
                也就是：先进先出。
                从一端放入元素的操作称为入队，取出元素为出队

                应用：多线程阻塞队列管理（登录，买票，数据库操作）

             Hash散列表：
                也叫哈希表，
                根据关键码和值 (key和value) 直接进行访问的数据结构，
                通过key和value来映射到集合中的一个位置，这样就可以很快找到集合中的对应元素

                利用hash表的优势，对于集合的查找元素时非常方便的，
                然而，因为哈希表是基于数组衍生的数据结构，在添加删除元素方面是比较慢的，所以很多时候需要用到一种数组链表来做
                
                HashSet<T>类主要是设计用来做高性能集运算的
                        例如对两个集合求交集、并集、差集等。
                        * 集合中包含一组不重复出现且无特性顺序的元素，HashSet拒绝接受重复的对象。
                    HashSet<T>的一些特性如下:
　　                    a. HashSet<T>中的值不能重复且没有顺序。
　　                    b. HashSet<T>的容量会按需自动添加。


             Linked List链表：
                链表是物理存储单元上非连续的、非顺序的存储结构，
                数据元素的逻辑顺序是通过链表的指针地址实现，每个元素包含两个结点，
                一个是存储元素的数据域 (内存空间)，另一个是指向下一个结点地址的指针域。
                根据指针的指向，链表能形成不同的结构，例如单链表，双向链表，循环链表等。
             
                优点：
                    链表是很常用的一种数据结构，不需要初始化容量，可以任意加减元素；
                    添加或者删除元素时只需要改变前后两个元素结点的指针域指向地址即可，所以添加，删除很快；

                缺点：
                    因为含有大量的指针域，占用空间较大；
                    查找元素需要遍历链表来查找，非常耗时。

                适用场景：
                    数据量较小，需要频繁增加，删除操作的场景

             Heap堆：
                n个元素的序列{k1,k2,ki,…,kn}当且仅当满足下关系时，称之为堆。
                (ki <= k2i,ki <= k2i+1)或者(ki >= k2i,ki >= k2i+1), (i = 1,2,3,4…n/2)，
                满足前者的表达式的成为小顶堆，满足后者表达式的为大顶堆

                因为堆有序的特点，一般用来做数组中的排序，称为堆排序

             Tree树：
                由n（n>=1）个有限节点组成一个具有层次关系的集合。
                把它叫做 “树” 是因为它看起来像一棵倒挂的树，也就是说它是根朝上，而叶朝下的。
                特点：
                    每个节点有零个或多个子节点；
                    没有父节点的节点称为根节点；
                    每一个非根节点有且只有一个父节点；
                    除了根节点外，每个子节点可以分为多个不相交的子树

                二叉树是一种比较有用的折中方案，
                它添加，删除元素都很快，并且在查找方面也有很多的算法优化，
                所以，二叉树既有链表的好处，也有数组的好处，是两者的优化方案，
                在处理大批量的动态数据方面非常有用

             Graph图：
                由结点的有穷集合V和边的集合E组成。
                其中，为了与树形结构加以区别，在图结构中常常将结点称为顶点，边是顶点的有序偶对，
                若两个顶点之间存在一条边，就表示这两个顶点具有相邻关系

                图是一种比较复杂的数据结构，在存储数据上有着比较复杂和高效的算法，
                分别有邻接矩阵 、邻接表、十字链表、邻接多重表、边集数组等存储结构
             */
        }
    }
}
