from flask import Flask, request, jsonify
from transformers import AutoTokenizer, AutoModel
import torch
from sklearn.metrics.pairwise import cosine_similarity
from transformers import BertTokenizer, BertModel
import torch
from sklearn.metrics.pairwise import cosine_similarity
from sentence_transformers import SentenceTransformer
import warnings
import os
import logging


warnings.filterwarnings("ignore", category=FutureWarning)

# Silence specific modules
logging.getLogger("transformers").setLevel(logging.ERROR)
logging.getLogger("huggingface_hub").setLevel(logging.ERROR)

# For tokenizers
os.environ["TOKENIZERS_PARALLELISM"] = "false"


app = Flask(__name__)

# Load pre-trained Sentence-BERT model
model_name = "bert-base-uncased"
tokenizer = AutoTokenizer.from_pretrained(model_name)
#model = AutoModel.from_pretrained(model_name)
model = SentenceTransformer('paraphrase-mpnet-base-v2')

def encode_sentence(sentence):
    # Use Sentence-BERT to get embeddings
    return model.encode(sentence)


def calculate_similarity(sentence1, sentence2):
    # Get embeddings for both sentences
    embedding1 = encode_sentence(sentence1)
    embedding2 = encode_sentence(sentence2)
    print (sentence1)
    print (sentence2)


    # Calculate cosine similarity between the embeddings
    similarity = cosine_similarity([embedding1], [embedding2])
    return similarity[0][0]


@app.route('/compare', methods=['POST'])
def compare_sentences():
    data = request.json
    sentence1 = data.get('sentence1')
    sentence2 = data.get('sentence2')



    similarity_score = calculate_similarity(sentence1, sentence2)

    # Convert the similarity score to a regular Python float before returning
    return jsonify({"similarity": float(similarity_score)})

if __name__ == '__main__':
    print("Server running at http://0.0.0.0:5000")	
    app.run(debug=False, host="0.0.0.0", port=5000)
