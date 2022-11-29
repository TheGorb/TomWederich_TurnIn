use rand::Rng;
use std::{io};

pub fn fahrenheit_celsius_converter(temperature: i32, f2c: bool) -> f32 {
    let float_temp = temperature as f32;
    if f2c {
        return (float_temp - 32.0) * 5.0 / 9.0;
    }
    return (float_temp * 1.8) + 32.0;
}

pub fn dice_roll(sides: u8) -> u8 {
    return rand::thread_rng().gen_range(1, sides);
}

pub fn multi_string(s: String) -> [String; 4] {
    return [
        format!("{}", s),
        format!("{}{}", s, "ONE"),
        format!("{}{}", s, "TWO"),
        format!("{}{}", s, "THREE"),
    ];
}

pub fn add_vowels(s: &mut String) {
    *s = s
        .replace("a", "aa")
        .replace("e", "ee")
        .replace("i", "ii")
        .replace("o", "oo")
        .replace("u", "uu");
    *s = s
        .replace("A", "AA")
        .replace("E", "EE")
        .replace("I", "II")
        .replace("O", "OO")
        .replace("U", "UU");
}

pub fn echo_split(whole: String, num: u32) {
    let first_string_part = String::from(whole.split_at(whole.len() / 2).0);
    let second_string_part = String::from(whole.split_at(whole.len() / 2).1);

    print!("{} ", first_string_part.repeat(num as usize));
    println!("{}", second_string_part.repeat(num as usize));
}

pub fn input_number(high: u32) -> Option<u32> {
    let mut user_input = String::new();
    let stdin = io::stdin();
    if stdin.read_line(&mut user_input).is_err() {
        return None;
    }
    let string_with_only_digit: String = user_input.chars().filter(|c| c.is_digit(10)).collect();

    if string_with_only_digit.len() > 0 {
        let number = string_with_only_digit.parse::<u32>().unwrap();
        println!("{}", number);
        if number == high {
            return None;
        } else {
            return Some(number % 10);
        }
    }
    return None;
}

/*
#[derive(Debug)]
enum Card {
    Diamond(String),
    Club(String),
    Heart(String),
    Spade(String)
}
pub fn draw_card() -> Card {

}
*/

pub fn input_coord(size: u8) -> (u8, u8) {
    let mut ended = false;
    let mut answer: (u8, u8) = (0, 0);
    let mut number_of_correct_answer = 0;

    while !ended {
        println!("enter coordinate for {} x {}:", size, size);
        let mut user_input = String::new();
        let stdin = io::stdin();
        if stdin.read_line(&mut user_input).is_ok() {
            let string_with_only_digit: String =
                user_input.chars().filter(|c| c.is_digit(10)).collect();
            if string_with_only_digit.len() > 0 {
                let number = string_with_only_digit.parse::<u8>().unwrap();
                if number > size {
                    println!("{:?} is out of bounds on a board of size {:?}", number, size);
                } else {
                    if number_of_correct_answer == 0 {
                        answer.0 = number;
                    } else {
                        answer.1 = number;
                        ended = true;
                    }
                    number_of_correct_answer += 1;
                }
            } else {
                println!("{:?} is not a number, error: invalid digit found in string", user_input.trim());
            }
        }
    }
    return answer;
}

pub fn madlib() {
    let mut answer: (String, String, String, String, String) = (String::new(), String::new(), String::new(), String::new(), String::new());
    let mut user_input = String::new();
    let stdin = io::stdin();

    println!("give me a noun");
    if stdin.read_line(&mut user_input).is_err() {
        answer.0 = String::from("fish");
    }
    answer.0 = String::clone(&user_input);
 
    println!("give me a adjective");
    user_input.clear();
    if stdin.read_line(&mut user_input).is_err() {
        answer.1 = String::from("cool");
    }
    answer.1 = String::clone(&user_input);

    println!("give me a past tense verb");
    user_input.clear();
    if stdin.read_line(&mut user_input).is_err() {
        answer.2 = String::from("ate");
    }
    answer.2 = String::clone(&user_input);

    println!("give me a noun");
    user_input.clear();
    if stdin.read_line(&mut user_input).is_err() {
        answer.3 = String::from("donkey");
    }
    answer.3 = String::clone(&user_input);

    println!("give me a noun");
    user_input.clear();
    if stdin.read_line(&mut user_input).is_err() {
        answer.4 = String::from("pastor");
    }
    answer.4 = String::clone(&user_input);

    println!("\nThe {} was really {}.", answer.0.trim(), answer.1.trim());
    println!("My mom {} the {} and then kicked the {}.", answer.2.trim(), answer.3.trim(), answer.4.trim());
}