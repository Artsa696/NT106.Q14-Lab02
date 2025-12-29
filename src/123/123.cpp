// 123.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include <string>
#include <cstdint>

static uint64_t str_hash64(const std::string &s) {
    uint64_t h = 14695981039346656037ull;
    for (unsigned char c : s) {
        h ^= (uint64_t)c;
        h *= 1099511628211ull;
    }
    return h;
}

static bool numLess(const std::string &a, const std::string &b) {
    int ia = 0; while (ia < (int)a.size() && a[ia] == '0') ++ia;
    int ib = 0; while (ib < (int)b.size() && b[ib] == '0') ++ib;
    int la = (int)a.size() - ia;
    int lb = (int)b.size() - ib;
    if (la != lb) return la < lb;
    if (la <= 0) return false; // both are zero
    for (int k = 0; k < la; ++k) {
        char ca = a[ia + k];
        char cb = b[ib + k];
        if (ca != cb) return ca < cb;
    }
    return false;
}

static void order_range(std::vector<int> &v, int l, int r, const std::vector<std::string> &keys) {
    if (l >= r) return;
    int i = l, j = r;
    const std::string &pivotVal = keys[v[(l + r) >> 1]];
    while (i <= j) {
        while (numLess(keys[v[i]], pivotVal)) ++i;
        while (numLess(pivotVal, keys[v[j]])) --j;
        if (i <= j) {
            int tmp = v[i]; v[i] = v[j]; v[j] = tmp;
            ++i; --j;
        }
    }
    if (l < j) order_range(v, l, j, keys);
    if (i < r) order_range(v, i, r, keys);
}

int main() {
    std::ios::sync_with_stdio(false);
    std::cin.tie(nullptr);

    int N;
    if (!(std::cin >> N)) return 0;
    std::string s;

    int cap = 1;
    while (cap < N * 4) cap <<= 1;
    int mask = cap - 1;

    std::vector<uint64_t> keysHash(cap, 0);
    std::vector<std::string> keys(cap);
    std::vector<char> used(cap, 0);
    std::vector<int> counts(cap, 0);

    for (int t = 0; t < N; ++t) {
        std::cin >> s;
        uint64_t h = str_hash64(s);
        int idx = (int)(h & (uint64_t)mask);
        while (true) {
            if (!used[idx]) {
                used[idx] = 1;
                keysHash[idx] = h;
                keys[idx] = s;
                counts[idx] = 1;
                break;
            } else if (keysHash[idx] == h && keys[idx] == s) {
                ++counts[idx];
                break;
            } else {
                idx = (idx + 1) & mask;
            }
        }
    }

    int maxcnt = 0;
    for (int i = 0; i < cap; ++i) if (used[i] && counts[i] > maxcnt) maxcnt = counts[i];
    if (maxcnt == 0) return 0;

    std::vector<std::vector<int>> buckets(maxcnt + 1);
    for (int i = 0; i < cap; ++i) if (used[i]) buckets[counts[i]].push_back(i);

    bool firstOut = true;
    for (int c = maxcnt; c >= 1; --c) {
        auto &bucket = buckets[c];
        if (bucket.empty()) continue;
        order_range(bucket, 0, (int)bucket.size() - 1, keys);
        for (int idx : bucket) {
            if (!firstOut) std::cout << '\n';
            firstOut = false;
            std::cout << keys[idx] << ' ' << counts[idx];
        }
    }
    return 0;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
