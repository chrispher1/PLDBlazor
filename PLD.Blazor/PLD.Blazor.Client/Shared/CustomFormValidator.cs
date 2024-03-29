﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;

namespace PLD.Blazor.Client.Shared
{
    public class CustomFormValidator : ComponentBase
    {
        private ValidationMessageStore? validationMessageStore;

        [CascadingParameter]
        private EditContext? CurrentEditContext { get; set; }

        #region Events

            protected override void OnInitialized()
            {
                if (CurrentEditContext == null)
                {
                    throw new InvalidOperationException(
                        $"{nameof(CustomFormValidator)} requires a cascading parameter of type {nameof(EditContext)}.");
                }

                validationMessageStore = new ValidationMessageStore(CurrentEditContext);

                CurrentEditContext.OnValidationRequested += (s, e) =>
                    validationMessageStore.Clear();
                CurrentEditContext.OnFieldChanged += (s, e) =>
                    validationMessageStore.Clear(e.FieldIdentifier);
            }

        #endregion Events

        #region Methods

            public void DisplayFormErrors(Dictionary<string, List<string>> errors)
            {
                foreach (var err in errors)
                {
                    validationMessageStore?.Add(CurrentEditContext.Field(err.Key), err.Value);
                }

                CurrentEditContext?.NotifyValidationStateChanged();
            }

            public void ClearFormErrors()
            {
                validationMessageStore?.Clear();
                CurrentEditContext?.NotifyValidationStateChanged();
            }

        #endregion Methods

    }
}