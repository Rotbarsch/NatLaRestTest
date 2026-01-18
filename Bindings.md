## Table of Contents
- [Namespace: Ekto.TestUtilities.SlimTestKit.StepDefinitions](#namespace-ektotestutilitiesslimtestkitstepdefinitions)
  - [Class: CurrentExecutionDirectoryBindings](#class-currentexecutiondirectorybindings)
  - [Class: DebugBindings](#class-debugbindings)
  - [Class: KeyboardBindings](#class-keyboardbindings)
  - [Class: ModalWindowBindings](#class-modalwindowbindings)
  - [Class: PropertyViewBindings](#class-propertyviewbindings)
  - [Class: TableBindings](#class-tablebindings)
  - [Class: TestDataManagement](#class-testdatamanagement)
- [Namespace: Slim.TestKit.FlaUI.BDD.Actions](#namespace-slimtestkitflauibddactions)
  - [Class: AutomationElementActions](#class-automationelementactions)
  - [Class: CheckBoxActions](#class-checkboxactions)
  - [Class: ClickActions](#class-clickactions)
  - [Class: ComboBoxActions](#class-comboboxactions)
  - [Class: CommonDialogActions](#class-commondialogactions)
  - [Class: ComponentGeneratorActions](#class-componentgeneratoractions)
  - [Class: CustomDialogActions](#class-customdialogactions)
  - [Class: FileActions](#class-fileactions)
  - [Class: GeneralActions](#class-generalactions)
  - [Class: ListActions](#class-listactions)
  - [Class: MasifSimulatorActions](#class-masifsimulatoractions)
  - [Class: MessageBoxActions](#class-messageboxactions)
  - [Class: ProgressBarActions](#class-progressbaractions)
  - [Class: TableActions](#class-tableactions)
  - [Class: TextBlockActions](#class-textblockactions)
  - [Class: TextBoxActions](#class-textboxactions)
  - [Class: TimerActions](#class-timeractions)
  - [Class: WaitActions](#class-waitactions)
  - [Class: WindowActions](#class-windowactions)

<a id="namespace-ektotestutilitiesslimtestkitstepdefinitions"></a>
# Namespace: Ekto.TestUtilities.SlimTestKit.StepDefinitions

<a id="class-currentexecutiondirectorybindings"></a>
## Class: CurrentExecutionDirectoryBindings

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| WhenTheUserStoresTheCurrentExecutionDirectoryInTestDataStoreVariable | When the user stores the current execution directory in TestDataStore variable '([^']\*)' |  |


<a id="class-debugbindings"></a>
## Class: DebugBindings
<br>            Step definitions for debugging purposes.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| Break | When ^break\\$ | Breaks the exeution when hit. |


<a id="class-keyboardbindings"></a>
## Class: KeyboardBindings
<br>            Bindings simulating keyboard input.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| WhenTheUserHitsTheKey | When the user hits the '([^']\*)' key | Simulates pressing a specific key.<br>*key*: The key to press. Must deserialize to  enum. |
| WhenTheUserTypes | When the user types '([^']\*)' | Simulates typing the given text.<br>*inputText*: Text to input. |


<a id="class-modalwindowbindings"></a>
## Class: ModalWindowBindings

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| SwitchToApplicationMainWindow | When ^the context switches back to the MainWindow\\$ |  |
| SwitchToModalWindow | When ^the context switches to the window with the name '(.\*)'\\$ |  |


<a id="class-propertyviewbindings"></a>
## Class: PropertyViewBindings

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| SelectRow | When ^the user selects the row describing the property '(.\*)' in property view '(.\*)'\\$ |  |
| SetPropertyViewValue | When ^the user sets property '(.\*)' to value '(.\*)' in property view '(.\*)'\\$ |  |


<a id="class-tablebindings"></a>
## Class: TableBindings
<br>            Remove this whole file when SlimTestKit supports clicking table cells natively.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| DoubleClickCellInRow | When ^the user double clicks the cell in column '(.\*)' in row with the following values in table '(.\*)':\\$ |  |


<a id="class-testdatamanagement"></a>
## Class: TestDataManagement

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| PrepareTestData | Given ^the dataset '(.\*)' is loaded\\$ |  |

<a id="namespace-slimtestkitflauibddactions"></a>
# Namespace: Slim.TestKit.FlaUI.BDD.Actions

<a id="class-automationelementactions"></a>
## Class: AutomationElementActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| ThenElementsAreAvailable | Then ^the following elements are available and (unique):\\$ |  |
| ThenElementsAreEnabled | Then ^the following elements are (enabled\\|disabled):\\$ |  |
| ThenElementsAreEnabled | Then ^the following elements have the enablement statuses:\\$ |  |
| ThenIsEnabled | Then ^'([^']\*)' is (enabled\\|disabled)\\$ |  |
| ThenTheElementIsAvailableAndUnique | Then ^'(.\*)' is available and (unique)\\$ |  |
| ThenTheElementIsNotAvailable | Then ^'(.\*)' is not available\\$ |  |
| WhenClickOnContextMenuElement | When ^the user clicks on item '(.\*)' in the context menu\\$ |  |
| WhenClickOnContextMenuElement | When ^the user clicks on item '(.\*)' in the '(.\*)' context menu\\$ |  |
| WhenHighlightForGivenTimeframe | When ^the user highlights '(.\*)' with '(.\*)' color\\$ |  |
| WhenHighlightOn | When ^the user highlights '(.\*)' with '(.\*)' color for '(.\*)' seconds?\\$ |  |
| WhenHighlightWithGivenColorForGivenTimeframe | When ^the user highlights '(.\*)'\\$ |  |


<a id="class-checkboxactions"></a>
## Class: CheckBoxActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| ThenCheckBoxesAreChecked | Then ^the following CheckBoxes are (checked\\|unchecked):\\$ |  |
| ThenCheckBoxesWithLabelsAreChecked | Then ^the following CheckBoxes with labels are (checked\\|unchecked):\\$ |  |
| ThenCheckboxHasLabel | Then ^CheckBox '([^']\*)' label is equal to '([^']\*)'\\$ |  |
| ThenCheckBoxIsChecked | Then ^CheckBox '([^']\*)' is (checked\\|unchecked)\\$ |  |
| ThenCheckBoxWithLabelIsChecked | Then ^CheckBox with label '([^']\*)' is (checked\\|unchecked)\\$ |  |
| WhenCheckTheCheckbox | When ^the user checks the CheckBox '([^']\*)'\\$ |  |
| WhenCheckTheCheckboxes | When ^the user checks the following CheckBoxes:\\$ |  |
| WhenCheckTheCheckboxesWithLabels | When ^the user checks the following CheckBoxes with labels:\\$ |  |
| WhenCheckTheCheckboxWithLabel | When ^the user checks the CheckBox with label '([^']\*)'\\$ |  |
| WhenUncheckTheCheckbox | When ^the user unchecks the CheckBox '([^']\*)'\\$ |  |
| WhenUncheckTheCheckboxes | When ^the user unchecks the following CheckBoxes:\\$ |  |
| WhenUnCheckTheCheckboxesWithLabels | When ^the user unchecks the following CheckBoxes with labels:\\$ |  |
| WhenUncheckTheCheckboxWithLabel | When ^the user unchecks the CheckBox with label '([^']\*)'\\$ |  |


<a id="class-clickactions"></a>
## Class: ClickActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| WhenClick | When ^the user clicks on '([^']\*)'\\$ |  |
| WhenDoubleClick | When ^the user double clicks on '([^']\*)'\\$ |  |
| WhenRightClick | When ^the user right clicks on '([^']\*)'\\$ |  |


<a id="class-comboboxactions"></a>
## Class: ComboBoxActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| ThenComboBoxesAreLoaded | Then ^the following ComboBoxes are (loaded):\\$ |  |
| ThenComboBoxIsLoaded | Then ^ComboBox '([^']\*)' is (loaded)\\$ |  |
| ThenComboBoxItemWithIndexIsSelected | Then ^the '([^']\*)'. ComboBoxItem from ComboBox '([^']\*)' is selected\\$ |  |
| ThenComboBoxItemWithTextIsSelected | Then ^ComboBoxItem with text '([^']\*)' from ComboBox '([^']\*)' is selected\\$ |  |
| WhenSelectItemByIndexFromCombobox | When ^the user selects '([^']\*)'. item from ComboBox '([^']\*)'\\$ |  |
| WhenSelectItemByIndexFromComboboxWithDropdownOpen | When ^the user selects '([^']\*)'. item from ComboBox '([^']\*)' with keeping the dropdown open\\$ |  |
| WhenSelectItemFromCombobox | When ^the user selects item '([^']\*)' from ComboBox '([^']\*)'\\$ |  |
| WhenSelectItemFromComboboxWithDropdownOpen | When ^the user selects item '([^']\*)' from ComboBox '([^']\*)' with keeping the dropdown open\\$ |  |


<a id="class-commondialogactions"></a>
## Class: CommonDialogActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| ThenVerifyFolderPath | Then ^folder path contains '(.\*)' in the AddressBar of the dialog\\$ |  |
| ThenVerifySelectedElement | Then ^(?:file\\|folder) '(.\*)' is selected in the main panel of the dialog\\$ |  |
| WhenCancel | When ^the user cancels the (?:open file\\|open folder\\|save file) dialog\\$ |  |
| WhenClickOnElement | When ^the user clicks on (?:file\\|folder) '(.\*)' in the main panel of the dialog\\$ |  |
| WhenCloseDialog | When ^the user closes the opened (?:open file\\|open folder\\|save file) dialog\\$ |  |
| WhenConfirmAction | When ^the user opens the selected (?:file\\|folder) by clicking on Open button\\$ |  |
| WhenConfirmAction | When ^the user saves the given file by clicking on Save button\\$ |  |
| WhenDoubleClickOnFile | When ^the user double clicks on the file '(.\*)' in the main panel of the dialog\\$ |  |
| WhenDoubleClickOnFolder | When ^the user double clicks on the folder '(.\*)' in the main panel of the dialog\\$ |  |
| WhenEnterElementPath | When ^the user enters (?:file\\|folder) path '(.\*)' in the TextBox of the dialog\\$ |  |
| WhenEnterFolderPathIntoAddressBar | When ^the user enters folder path '(.\*)' in the AddressBar of the dialog\\$ |  |
| WhenOpenDialogWithClick | When ^the user opens (open file\\|open folder\\|save file) dialog by clicking on '([^']\*)'\\$ |  |
| WhenOpenElementByEnteringNamePlusOpenButton | When ^the user opens the (?:file\\|folder) '(.\*)' with path by clicking on Open button\\$ |  |
| WhenOpenFileWithDoubleClicking | When ^the user opens the file '(.\*)' by double clicking on its name\\$ |  |
| WhenOpenFolderWithDoubleClicking | When ^the user opens the folder '(.\*)' by double clicking on its name and clicking on Open button\\$ |  |
| WhenPressEnter | When ^the user opens the selected file by pressing ENTER\\$ |  |
| WhenPressEnter | When ^the user saves the given file by pressing ENTER\\$ |  |
| WhenSaveFileByEnteringNamePlusEnterKey | When ^the user saves the file by entering path '(.\*)' in the TextBox and pressing ENTER\\$ |  |
| WhenSaveFileByEnteringNamePlusSaveButton | When ^the user saves the file by entering path '(.\*)' in the TextBox and clicking on Save button\\$ |  |
| WhenSaveFileWithEnter | When ^the user saves the file by entering file name '(.\*)' in the TextBox and pressing ENTER\\$ |  |
| WhenSaveFileWithSaveButton | When ^the user saves the file by entering file name '(.\*)' in the TextBox and clicking on Save button\\$ |  |
| WhenSelectFileByEnteringNamePlusEnter | When ^the user opens the file '(.\*)' with path by pressing ENTER\\$ |  |
| WhenSelectFileBySingleClickPlusEnter | When ^the user opens the file '(.\*)' by clicking on its name and pressing ENTER\\$ |  |
| WhenSelectFileBySingleClickPlusOpenButton | When ^the user opens the (?:file\\|folder) '(.\*)' by clicking on its name and clicking on Open button\\$ |  |


<a id="class-componentgeneratoractions"></a>
## Class: ComponentGeneratorActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| GivenDataFromFolderIsLoadedIntoEris | Given ^the data from folder '([^']\*)' is loaded into ERIS\\$ |  |
| GivenDataFromFolderIsLoadedIntoErisUntilStep | Given ^the data from folder '([^']\*)' is loaded into ERIS until step '([^']\*)'\\$ |  |
| GivenDataFromFolderIsLoadedIntoErisUntilStepWithoutCommit | Given ^the data from folder '([^']\*)' is loaded into ERIS until step '([^']\*)' without committing the transaction\\$ |  |
| GivenDataFromFolderIsLoadedIntoErisWithoutCommit | Given ^the data from folder '([^']\*)' is loaded into ERIS without committing the transaction\\$ |  |
| GivenSuffix | Given ^the suffix '([^']\*)' for the ComponentGenerator\\$ |  |
| GivenSuffixGenerated | Given ^a suffix is generated for the ComponentGenerator\\$ |  |
| GivenSuffixIsGeneratedFromRegex | Given ^a suffix is generated from regex '(.\*)' for the ComponentGenerator\\$ |  |


<a id="class-customdialogactions"></a>
## Class: CustomDialogActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| ClickOnButtonWithTextInOpenDialog | When ^the user clicks on button with text '([^']\*)' in the custom dialog\\$ |  |
| WhenCloseDialog | When ^the user closes the (custom dialog) '([^']\*)'\\$ |  |
| WhenCloseModalDialog | When ^the user closes the opened custom dialog\\$ |  |
| WhenOpenDialog | When ^the user opens a (custom dialog) by clicking on '([^']\*)'\\$ |  |


<a id="class-fileactions"></a>
## Class: FileActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| GivenTheDataIsStored | Given ^the data '([^']\*)' is stored\\$ |  |
| GivenTheDataIsStoredWithIdentifier | Given ^the data '([^']\*)' is stored with identifier '([^']\*)'\\$ |  |
| GivenTheFileIsStored | Given ^the data from file '([^']\*)' is stored\\$ |  |
| GivenTheFileIsStoredWithIdentifier | Given ^the data from file '([^']\*)' is stored with identifier '([^']\*)'\\$ |  |
| ThenFileContainsContent | Then ^the data in file '([^']\*)' contains content '([^']\*)'\\$ |  |
| ThenFileContainsContentInFile | Then ^the data in file '([^']\*)' contains content defined in '([^']\*)'\\$ |  |
| ThenTextboxContainsValueFromStorage | Then ^TextBox '([^']\*)' contains the value of variable '([^']\*)' in test data storage\\$ |  |
| WhenCopyFileToDestination | When ^the user copies file '([^']\*)' to folder '([^']\*)'\\$ |  |
| WhenDeleteFile | When ^the user deletes file '([^']\*)'\\$ |  |
| WhenTextEnteredFromStorage | When ^the user enters text from test data storage into TextBox '([^']\*)'\\$ |  |
| WhenTextEnteredFromStorageNamedElement | When ^the user enters text from identifier '([^']\*)' in test data storage into TextBox '([^']\*)'\\$ |  |


<a id="class-generalactions"></a>
## Class: GeneralActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| GivenTheFileLogLevelIsSetTo | Given ^the file log level is set to '(.\*)'\\$ |  |
| GivenTheLogLevelIsSetTo | Given ^the log level is set to '(.\*)'\\$ |  |
| GivenTheTimeoutIsReverted | Given ^the timeout for actions is reverted to the global configuration\\$ |  |
| GivenTheTimeoutIsSetTo | Given ^the timeout for actions is set to '(.\*)' seconds?\\$ |  |
| ThenTheCurrentfileLogLevelIs | Then ^the current file log level is '(.\*)'\\$ |  |
| ThenTheCurrentLogLevelIs | Then ^the current log level is '(.\*)'\\$ |  |
| WhenCaptureScreenshot | When ^the user captures screenshot as '(.\*)'\\$ |  |
| WhenRemoveFocus | When ^the test removes focus from element that was previously in focus\\$ |  |
| WhenSetFocusTo | When ^the test puts the element '(.\*)' in focus\\$ |  |


<a id="class-listactions"></a>
## Class: ListActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| ThenItemSelectedInList | Then ^ListBoxItem with text '([^']\*)' from List '([^']\*)' is selected\\$ |  |
| ThenListIsLoaded | Then ^List '([^']\*)' is (loaded)\\$ |  |
| ThenListsAreLoaded | Then ^the following Lists are (loaded):\\$ |  |
| WhenSelectItemFromTheList | When ^the user selects item '([^']\*)' from the List '([^']\*)'\\$ |  |


<a id="class-masifsimulatoractions"></a>
## Class: MasifSimulatorActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| GivenTheSimulatorIsStartedAndReady | Given ^the Simulator is started and ready\\$ |  |
| GivenTheSimulatorIsStartedAndReadyWithSnapshotFile | Given ^the Simulator is started and ready with Snapshot file '(.\*)'\\$ |  |
| WhenActivatingSimulatorFaultCategory | When ^the user activates FaultCategory '(.\*)' on Simulator '(.\*)'\\$ |  |
| WhenRestoringTheSimulatorDataModelFromSnapshot | When ^the user restores the Simulator DataModel from Snapshot file '(.\*)'\\$ |  |
| WhenSavingTheSimulatorDataModelSnapshotToFile | When ^the user saves the Simulator DataModel Snapshot to file '(.\*)'\\$ |  |
| WhenStoppingAllActiveSimulatorFaults | When ^the user stops all active Simulator Faults\\$ |  |
| WhenUserUpdatesTheSimulatorDataModelWithFile | When ^the user updates the Simulator DataModel '(.\*)' with file '(.\*)'\\$ |  |


<a id="class-messageboxactions"></a>
## Class: MessageBoxActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| ClickOnButtonInDialog | When ^the user clicks on '(Yes\\|No\\|Ja\\|Nein\\|OK\\|Cancel\\|Abbrechen)' button in the (message box)\\$ |  |
| ClickOnButtonWithTextInDialog | When ^the user clicks on button with text '([^']\*)' in the message box\\$ |  |
| VerifyMessageBoxText | Then ^the (message box) text is (equal to '([^']\*)')\\$ |  |
| VerifyMessageBoxTextContains | Then ^the (message box) text (contains '([^']\*)')\\$ |  |
| WhenCloseDialog | When ^the user closes the (message box) '([^']\*)'\\$ |  |
| WhenCloseModalDialog | When ^the user closes the opened message box\\$ |  |
| WhenCloseModalDialogByEnter | When ^the user closes the message box by pressing ENTER\\$ |  |
| WhenCloseModalDialogByEscape | When ^the user closes the message box by pressing Escape\\$ |  |
| WhenOpenDialog | When ^the user opens a (message box) by clicking on '([^']\*)'\\$ |  |
| WhenOpenDialog | When ^the user opens a (message box) by pressing ENTER\\$ |  |


<a id="class-progressbaractions"></a>
## Class: ProgressBarActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| ThenProgressBarIsDisabled | Then ^the progress bar '([^']\*)' is disabled\\$ |  |
| ThenProgressBarIsNotAvailable | Then ^the progress bar '([^']\*)' is not available\\$ |  |
| ThenProgressBarIsVisible | Then ^the progress bar '([^']\*)' is visible\\$ |  |


<a id="class-tableactions"></a>
## Class: TableActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| ThenCellByColumnContainsMultilineValueInTable | Then ^the cell in column '([^']\*)' contains the following multiline text in the identified row:\\$ |  |
| ThenCellByColumnContainsValueInTable | Then ^the cell in column '([^']\*)' (contains '([^']\*)') in the identified row\\$ |  |
| ThenCellByColumnContainsValueInTableOld | Then ^the cell in column '([^']\*)' contains the value '([^']\*)' in the identified row\\$ |  |
| ThenCellByColumnHasMultilineValueInTable | Then ^the cell in column '([^']\*)' is equal to the following multiline text in the identified row:\\$ |  |
| ThenCellByColumnHasValueInTable | Then ^the cell in column '([^']\*)' has the value '([^']\*)' in the identified row\\$ |  |
| ThenCellByColumnIsEqualToInTable | Then ^the cell in column '([^']\*)' is (equal to '([^']\*)') in the identified row\\$ |  |
| ThenCellByIndexContainsValueInTable | Then ^the cell in the '([^']\*)'. column (contains '([^']\*)') in the identified row\\$ |  |
| ThenCellByIndexContainsValueInTableOld | Then ^the cell in the '([^']\*)'. column contains the value '([^']\*)' in the identified row\\$ |  |
| ThenCellByIndexHasValueInTable | Then ^the cell in the '([^']\*)'. column has the value '([^']\*)' in the identified row\\$ |  |
| ThenCellByIndexIsEqualToInTable | Then ^the cell in the '([^']\*)'. column is (equal to '([^']\*)') in the identified row\\$ |  |
| ThenVerifyRowsByIndexes | Then ^the rows with the following indexes are selected in table '([^']\*)':\\$ |  |
| ThenVerifyRowsByValues | Then ^the rows with the following values are selected in table '([^']\*)':\\$ |  |
| WhenClickOnColumnInIdentifierRow | When ^the user clicks in the cell in '([^']\*)' column in the identified row\\$ |  |
| WhenClickOnIdentifiedRow | When ^the user clicks on the identified row\\$ |  |
| WhenEditCellByColumnNameAndType | When ^the user edits the cell in column '([^']\*)' in the identified row with (datetime\\|editable combobox\\|combobox\\|numeric text\\|multiline text\\|text\\|file selector\\|folder selector) value '([^']\*)'\\$ |  |
| WhenEditMultilineCellByColumnName | When ^the user edits the cell in column '([^']\*)' in the identified row with the following multiline text value:\\$ |  |
| WhenEditMultipleCellsByTableColumnNameAndType | When ^the user edits the cells in column '([^']\*)' in table '([^']\*)' with the following values:\\$ |  |
| WhenEditMultipleCellsInRowsByTableName | When ^the user edits the cells in column '([^']\*)' in table '([^']\*)' at the specified row indices with the following values:\\$ |  |
| WhenIdentifyRowInTableByRowNumber | When ^the user identifies the '([^']\*)'. row in table '([^']\*)'\\$ |  |
| WhenIdentifyRowInTableByValuesInColumns | When ^the user identifies the row in table '([^']\*)' with the following values:\\$ |  |
| WhenSelectEveryRowBetweenRowNumbers | When ^the user selects every row in table '([^']\*)' between rows with row numbers '([^']\*)' and '([^']\*)'\\$ |  |
| WhenSelectEveryRowBetweenRowNumbersAndColumn | When ^the user selects every row by clicking on column '([^']\*)' in table '([^']\*)' between rows with row numbers '([^']\*)' and '([^']\*)'\\$ |  |
| WhenSelectEveryRowBetweenValues | When ^the user selects every row in table '([^']\*)' between rows with the following values:\\$ |  |
| WhenSelectEveryRowBetweenValuesAndColumn | When ^the user selects every row by clicking on column '([^']\*)' in table '([^']\*)' between rows with the following values:\\$ |  |
| WhenSelectMultipleRowsByRowNumbers | When ^the user selects the rows in table '([^']\*)' with the following row numbers:\\$ |  |
| WhenSelectMultipleRowsByRowNumbersWithColumn | When ^the user selects the rows by clicking on column '([^']\*)' in table '([^']\*)' with the following row numbers:\\$ |  |
| WhenSelectMultipleRowsByValues | When ^the user selects the rows in table '([^']\*)' with the following values:\\$ |  |
| WhenSelectMultipleRowsByValuesAndColumn | When ^the user selects the rows by clicking on column '([^']\*)' in table '([^']\*)' with the following values:\\$ |  |


<a id="class-textblockactions"></a>
## Class: TextBlockActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| ThenTextBlockEndsWith | Then ^TextBlock '([^']\*)' (ends with '([^']\*)')\\$ |  |
| ThenTextBlockIsEmpty | Then ^TextBlock '([^']\*)' is (empty\\|not empty)\\$ |  |
| ThenTextBlockMustContain | Then ^TextBlock '([^']\*)' (contains '([^']\*)')\\$ |  |
| ThenTextBlockMustEqualTo | Then ^TextBlock '([^']\*)' is (equal to '([^']\*)')\\$ |  |
| ThenTextBlockStartsWith | Then ^TextBlock '([^']\*)' (starts with '([^']\*)')\\$ |  |


<a id="class-textboxactions"></a>
## Class: TextBoxActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| ThenTextBoxEndsWith | Then ^TextBox '([^']\*)' (ends with '([^']\*)')\\$ |  |
| ThenTextBoxIsEmpty | Then ^TextBox '([^']\*)' is (empty\\|not empty)\\$ |  |
| ThenTextBoxMustBeEqualTo | Then ^TextBox '([^']\*)' is (equal to '([^']\*)')\\$ |  |
| ThenTextBoxMustContain | Then ^TextBox '([^']\*)' (contains '([^']\*)')\\$ |  |
| ThenTextBoxStartsWith | Then ^TextBox '([^']\*)' (starts with '([^']\*)')\\$ |  |
| WhenClearTextbox | When ^the user clears TextBox '(.\*)'\\$ |  |
| WhenEnterIntoTextboxViaKeyboard | When ^the user enters '([^']\*)' in the TextBox '([^']\*)' via keyboard\\$ |  |
| WhenSetTextBox | When ^the user sets the value to '([^']\*)' in the TextBox '([^']\*)'\\$ |  |
| WhenTextBoxAppendText | When ^the user appends text '([^']\*)' to TextBox '([^']\*)'\\$ |  |
| WhenTextBoxAppendTextViaKeyboard | When ^the user appends text '([^']\*)' to TextBox '([^']\*)' via keyboard\\$ |  |
| WhenYouTypeInTheTextBox | When ^the user types '([^']\*)' in the TextBox '([^']\*)'\\$ |  |


<a id="class-timeractions"></a>
## Class: TimerActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| ThenTheTestExecutionIsCompletedWithinSeconds | Then the test execution is completed within '([^']\*)' seconds? |  |
| ThenTheTimerWithNameIsCompletedWithinSeconds | Then the timer with name '([^']\*)' is completed within '([^']\*)' seconds? |  |
| WhenATimerIsStartedWithName | When a timer is started with name '([^']\*)' |  |


<a id="class-waitactions"></a>
## Class: WaitActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| WhenWaitForSeconds | When ^the user waits for '(.\*)' seconds?\\$ |  |
| WhenWaitToAppear | When ^the user waits for '(.\*)' to appear?\\$ |  |
| WhenWaitToDisappear | When ^the user waits for '(.\*)' to disappear?\\$ |  |


<a id="class-windowactions"></a>
## Class: WindowActions

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| GivenTheApplicationIsStarted | Given ^the UI is started\\$ |  |
| GivenTheApplicationIsStarted | Given ^the UI is started and active\\$ |  |
| GivenTheApplicationIsStartedInSeconds | Given ^the UI is started in '(\d+)' seconds?\\$ |  |
| GivenTheElementIsActive | Given ^'(.\*)' is active in the current window\\$ |  |
| GivenTheWindowWithAutomationIdContainingIsActive | Given ^the window with automation ID containing '([^']\*)' is active\\$ |  |
| GivenTheWindowWithAutomationIdEqualToIsActive | Given ^the window with automation ID equal to '([^']\*)' is active\\$ |  |
| GivenTheWindowWithNameContainingIsActive | Given ^the window with name containing '([^']\*)' is active\\$ |  |
| GivenTheWindowWithNameEqualToIsActive | Given ^the window with name equal to '([^']\*)' is active\\$ |  |
| GivenTheWindowWithProcessNameContainingIsActive | Given ^the window with process name containing '([^']\*)' is active\\$ |  |
| GivenTheWindowWithProcessNameEqualToIsActive | Given ^the window with process name equal to '([^']\*)' is active\\$ |  |
| SetMainToForeground | When ^the user sets the main window to foreground\\$ |  |
| ThenInformationPopupIsVisibleWithText | Then ^the information popup with identifier '(.\*)' has text '(.\*)'\\$ |  |
| ThenTheWindowWithAutomationIdContainingIsActive | Then ^the window with automation ID containing '([^']\*)' is active\\$ |  |
| ThenTheWindowWithAutomationIdEqualToIsActive | Then ^the window with automation ID equal to '([^']\*)' is active\\$ |  |
| ThenTheWindowWithNameContainingIsActive | Then ^the window with name containing '([^']\*)' is active\\$ |  |
| ThenTheWindowWithNameEqualToIsActive | Then ^the window with name equal to '([^']\*)' is active\\$ |  |
| ThenTheWindowWithProcessNameContainingIsActive | Then ^the window with process name containing '([^']\*)' is active\\$ |  |
| ThenTheWindowWithProcessNameEqualToIsActive | Then ^the window with process name equal to '([^']\*)' is active\\$ |  |

