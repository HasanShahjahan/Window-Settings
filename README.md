# WindowSettings
Settings Window using WPF MVVM Pattern on .Net Core 3.1

# The numeric range of the slider can be set by 2 number input fields (minimum and maximum).
#The current value can be set by an additional number input field.
# The number input fields influence each other:
      • The value cannot be outside minimum or maximum.
      • If this rule is not fulfilled, the user should get a visual feedback (for example red text color or red outline of the number field).   
# A segmented control is used to switch the Rounding mode between an Integer or Double type as the number format of the fields minimum, maximum and value.
# Number of digits (if Double is selected) can be set in an additional input field (this will be disabled if Integer is selected).
