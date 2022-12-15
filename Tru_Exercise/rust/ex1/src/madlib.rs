impl Madlib {
    /*instaniates a new MadLib instance, ready to be filled with content.*/
	pub fn new() -> Self {
        
    }

    /*This function takes in to Optional parameters. The first story corresponds to parts of the MadLib that are static, the framework of the story. The Optional variable prompt corresponds to what type of word the user will be prompted to fill at the end of the story &str.*/
	pub fn add_content(&mut self, story: Option<&str>, prompt: Option<&str>) {

    }

    /*This begins the user interaction. The MadLib struct will read out the prompts it has stored from add_content and take in user input and store it within its memory. If the struct has no prompts it does nothing.*/
	pub fn prompt(&mut self) {}

    /*This function prints out the Strings stored from add_content() as followed by the Strings collected from prompt(), because add content has Options for parameters, the MadLib should be ablle to handle all possible values. If there is nothing stored in the struct it does nothing.*/
	pub fn read(&self) {}
}