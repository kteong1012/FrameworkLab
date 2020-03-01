using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllerBase
{
    private ModelBase _model;
    public ModelBase Model { get => _model; private set => _model = value; }

    public ControllerBase()
    {
        _model = null;
    }
    public ControllerBase(ModelBase model)
    {
        _model = model;
    }
}
