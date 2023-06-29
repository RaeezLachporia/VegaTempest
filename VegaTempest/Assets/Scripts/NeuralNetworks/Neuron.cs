using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Neuron : MonoBehaviour
{
	public List<Synapses> InputSynapses { get; set; }
	public List<Synapses> OutputSynapses { get; set; }
	public double BiasDelta { get; set; }
	public double Value { get; set; }
	public double Bias { get; set; }
	public double Gradient { get; set; }
	public Neuron(IEnumerable<Neuron> NeuronInput) 
	{
		foreach (var inputNeuron in NeuronInput)
		{
			var synapse = new Synapses(inputNeuron, this);
			inputNeuron.OutputSynapses.Add(synapse);
			InputSynapses.Add(synapse);
		}
	}
	public Neuron()
	{
		InputSynapses = new List<Synapses>();
		OutputSynapses = new List<Synapses>();
		Bias = neuralNet.GetRandom();
	}
	public virtual double CalculateValue()
	{
		return Value = Sigmoid.Output(InputSynapses.Sum(a => a.Weight * a.InputNeuron.Value) + Bias);
	}
	public double CalculateError(double target)
	{
		return target - Value;
	}
}
public class Synapses
{
	public Neuron InputNeuron { get; set; }
	public Neuron OutputNeuron { get; set; }
	public double Weight { get; set; }
	public double WeightDelta { get; set; }

	public Synapses(Neuron Neuroninput, Neuron Neuronoutput)
	{
		InputNeuron = Neuroninput;
		OutputNeuron = Neuronoutput;
		Weight = neuralNet.GetRandom();
	}
}
public static class Sigmoid
{
	public static double Output(double x)
	{
		return x < -45.0 ? 0.0 : x > 45.0 ? 1.0 : 1.0 / (1.0 + Mathf.Exp((float)-x));
	}

	public static double Derivative(double x)
	{
		return x * (1 - x);
	}
}
public class DataSet
{
	public double[] Values { get; set; }
	public double[] Targets { get; set; }

	public DataSet(double[] values, double[] targets)
	{
		Values = values;
		Targets = targets;
	}
}

