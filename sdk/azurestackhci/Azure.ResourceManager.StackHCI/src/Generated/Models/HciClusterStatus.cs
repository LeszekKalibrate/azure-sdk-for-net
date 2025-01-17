// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.StackHCI.Models
{
    /// <summary> Status of the cluster agent. </summary>
    public readonly partial struct HciClusterStatus : IEquatable<HciClusterStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="HciClusterStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public HciClusterStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NotYetRegisteredValue = "NotYetRegistered";
        private const string ConnectedRecentlyValue = "ConnectedRecently";
        private const string NotConnectedRecentlyValue = "NotConnectedRecently";
        private const string DisconnectedValue = "Disconnected";
        private const string ErrorValue = "Error";

        /// <summary> NotYetRegistered. </summary>
        public static HciClusterStatus NotYetRegistered { get; } = new HciClusterStatus(NotYetRegisteredValue);
        /// <summary> ConnectedRecently. </summary>
        public static HciClusterStatus ConnectedRecently { get; } = new HciClusterStatus(ConnectedRecentlyValue);
        /// <summary> NotConnectedRecently. </summary>
        public static HciClusterStatus NotConnectedRecently { get; } = new HciClusterStatus(NotConnectedRecentlyValue);
        /// <summary> Disconnected. </summary>
        public static HciClusterStatus Disconnected { get; } = new HciClusterStatus(DisconnectedValue);
        /// <summary> Error. </summary>
        public static HciClusterStatus Error { get; } = new HciClusterStatus(ErrorValue);
        /// <summary> Determines if two <see cref="HciClusterStatus"/> values are the same. </summary>
        public static bool operator ==(HciClusterStatus left, HciClusterStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="HciClusterStatus"/> values are not the same. </summary>
        public static bool operator !=(HciClusterStatus left, HciClusterStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="HciClusterStatus"/>. </summary>
        public static implicit operator HciClusterStatus(string value) => new HciClusterStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is HciClusterStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(HciClusterStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
