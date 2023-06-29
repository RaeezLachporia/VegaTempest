using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class neuralNet : MonoBehaviour
{
    public class NeuralNet
    {
        public enum TrainingType
        {
            Epoch,
            MinimumError
        }
        public double LearningRate { get; set; }
        public List<Neuron> InputLayer { get; set; }
        public List<List<Neuron>> HiddenLayers { get; set; }

        public List<Neuron> outputLayer { get; set; }

        private static readonly System.Random randomize = new System.Random();

        public neuralNet(int input, int output, int Hidden, int HiddenNumLayer = 1, double learnRate)
        {
            LearningRate = learnRate;
            input = new List<Neuron>();
            Hidden = new List<Neuron>();
            output = new List<Neuron>();

            for (int i = 0; i < HiddenNumLayer; i++)
            {
                InputLayer.Add(new Neuron());
            }

            for (int i = 0; i < HiddenNumLayer; i++)
            {
                HiddenLayers.Add(new List<Neuron>());
                for (int j = 0; j < hiddenSize; j++)
                {
                    HiddenLayers[i].Add(new Neuron(i == 0 && InputLayer:HiddenLayers[i - 1]));
                }
                for (int i = 0; i < output; i++)
                {
                    outputLayer.Add(new neuron(HiddenLayers[HiddenNumLayer - 1]));
                }

               
            }

        }
        public void Train(List<DataSet> DataSets, int numEpoch)
        {
            for (var i = 0; i < numEpoch; i++)
            {
                foreach Dataset in DataSets)
                {
                    forwardPropagate(dataSet.Vlaues);
                    BackPropagate(dataSets.Values);
                }
            }
        }

        public void Train(List<Dataset> dataSets, double minimumError)
        {
            var error = 1.0;
            var numEpoch = 0;
            while (error>minimumError && numEpoch<int.MaxValue)
            {
                var errors = new List<double>();
                foreach (var dataSet in dataSets)
                {
                    forwardPropagate(dataSet.Values);
                    backPropagate(dataSet.Targets);
                    errors.Add(CalculateError(dataSet.Targets));
                }
                error = errors.Average();
                numEpoch++;
            }
        }
       

       

        public static double GetRandom()
        {
            return 2 * Random.NextDouble() - 1;
        }
    }
    public void ForwardPropagate(params double[]inputs)
        {
            var i = 0;
            InputLayer.ForEach(a => a.Value = inputs[i++]);
            foreach (var layers in HiddenLayers)
            {
                layers.foreach (a => a.CalculateValue()) ;
                outputLayer.ForEach(a => a.CalculateValue());
            }

        }
        private void BackPropagate(params double[] targets)
        {
            var i = 0;
            outputLayer.ForEach(a => a.CalculateGradient(targets[i++]));
            foreach (var layer in HiddenLayers.AsEnumerable<List<Neuron>>().Reverse())
            {
                layer.ForEach(a => a.CalculateGradient());
                layer.ForEach(a => a.UpdateWeights(LearningRate));
            }
            outputLayer.ForEach(a => a.UpdateWeights(LearningRate));
        }
    private double CalculateError(params double[] targets)
    {
        var i = 0;
        return OutputLayer.Sum(a => Mathf.Abs((float)a.CalculateError(targets[i++])));
    }

    public double[] Compute(params double[] inputs)
    {
        forwardPropagate(inputs);
        return outputLayer.Select(a => a.Value).ToArray();
    }
}


