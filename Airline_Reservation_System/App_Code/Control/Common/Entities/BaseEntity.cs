using System;

namespace Control.Common;

public class BaseEntity
{
    private long _id;
    private DateTime _creationTime;
    private DateTime _updateTime;

    public long İd
    {
        get => _id;
        set => _id = value;
    }

    public DateTime CreationTime
    {
        get => _creationTime;
        set => _creationTime = value;
    }

    public DateTime UpdateTime
    {
        get => _updateTime;
        set => _updateTime = value;
    }
}