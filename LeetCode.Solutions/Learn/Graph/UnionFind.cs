﻿namespace LeetCode.Solutions.Learn.Graph;

// Quick Find
// https://leetcode.com/explore/learn/card/graph/618/disjoint-set/3878/
public class UnionFind
{
    private readonly int[] _root;

    public UnionFind(int numberOfElements)
    {
        _root = new int[numberOfElements];

        for (var i = 0; i < numberOfElements; i++)
        {
            var value = i + 1;
            _root[i] = value;
        }
    }

    public void Union((int left, int right) vertices)
    {
        var rootOfLeft = Find(vertices.left);
        var rootOfRight = Find(vertices.right);
        
        if (rootOfLeft != rootOfRight)
        {
            for (var i = 0; i < _root.Length; i++)
            {
                if (_root[i] == rootOfRight)
                {
                    _root[i] = rootOfLeft;
                }
            }
        }
    }

    public bool Connected((int left, int right) vertices)
    {
        return Find(vertices.left) == Find(vertices.right);
    }

    private int Find(int vertex)
    {
        return _root[GetIndex(vertex)];
    }

    private int GetIndex(int value)
    {
        return value - 1;
    }
}