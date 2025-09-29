def validate_tone(tone):
    valid_tones = {"neutral", "excited", "calm", "angry"}
    return tone.lower() in valid_tones

def validate_context(context):
    valid_contexts = {"combat", "lesson", "practice"}
    return context.lower() in valid_contexts

def format_response(data, success=True):
    return {
        "data": data,
        "success": success,
        "timestamp": strftime("%Y-%m-%d %H:%M:%S", gmtime())
    }
